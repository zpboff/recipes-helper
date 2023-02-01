using System.Text;
using System.Text.Json;
using Core.MessageBus.Public;
using Core.MessageBus.RabbitMQ.Exceptions;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Core.MessageBus.RabbitMQ;

public class MessageConsumer: IMessageConsumer
{
    private readonly ILogger<MessageConsumer> _logger;
    private readonly IBusChannelFactory _channelFactory;
    private IMessageBusSettings? _settings;
    private BusConnection? _connection;

    public MessageConsumer(IBusChannelFactory channelFactory, ILogger<MessageConsumer> logger)
    {
        _channelFactory = channelFactory;
        _logger = logger;
    }

    public IMessageConsumer Initialize(IMessageBusSettings settings)
    {
        _settings = settings;
        _connection = _channelFactory.CreateConnection(settings);

        return this;
    }

    public void OnMessage<TMessage>(string caller, Func<TMessage, Task> handler) where TMessage : class
    {
        if (_settings is null)
        {
            throw new BusConnectionClosedException($"Bus settings is not defined for {caller}");
        }
        
        if (_connection is null)
        {
            throw new BusConnectionNotInitializedException($"Connection is not defined for {caller}");
        }

        if (_connection.Channel.IsClosed)
        {
            throw new BusConnectionClosedException($"Connection is not defined for {caller}");
        }
        
        var exchangeName = ExchangeNameGenerator.GenerateExchangeName<TMessage>();
        var queueName = caller;
            
        _connection.Channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
        _connection.Channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);
        _connection.Channel.QueueBind(queueName, exchangeName, "");
            
        var consumer = new EventingBasicConsumer(_connection.Channel);
        consumer.Received += async (modell, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var model = JsonSerializer.Deserialize<TMessage>(message);

            await handler(model!);
        };

        _connection.Channel.BasicConsume(queueName, true, consumer);
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}