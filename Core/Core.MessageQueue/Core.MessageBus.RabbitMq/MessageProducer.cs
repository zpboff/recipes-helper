using Core.MessageBus.Public;
using Core.Utilities;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Core.MessageBus.RabbitMQ;

public class MessageProducer: IMessageProducer
{
    private readonly ILogger<MessageProducer> _logger;
    private readonly IBusChannelFactory _channelFactory;
    private IMessageBusSettings? _settings;

    public MessageProducer(IBusChannelFactory channelFactory, ILogger<MessageProducer> logger)
    {
        _channelFactory = channelFactory;
        _logger = logger;
    }

    public IMessageProducer Initialize(IMessageBusSettings settings)
    {
        _settings = settings;
        
        return this;
    }

    public void Produce<T>(IMessageBusSettings settings, T message) where T : class, new()
    {
        throw new NotImplementedException();
    }

    public void Produce<TMessage>(TMessage message) where TMessage: class, new()
    {
        if (_settings is null)
        {
            _logger.LogError($"Bus settings is not defined for {nameof(MessageProducer)}");
            return;
        }
        
        using var connection = _channelFactory.CreateConnection(_settings);
        var exchangeName = ExchangeNameGenerator.GenerateExchangeName<TMessage>();
        connection.Channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, autoDelete: false);
            
        connection.Channel.BasicPublish(exchangeName, "", null, ObjectToByteArrayConverter.Convert(message));
    }
}

