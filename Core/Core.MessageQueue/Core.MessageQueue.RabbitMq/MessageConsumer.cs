using System.Text;
using System.Text.Json;
using Core.MessageQueue.Public;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Core.MessageQueue.RabbitMQ;

public class MessageConsumer: IMessageConsumer
{
    private readonly IQueueChannelFactory _channelFactory;

    public MessageConsumer(IQueueChannelFactory channelFactory)
    {
        _channelFactory = channelFactory;
    }

    public void OnMessage<TMessage>(IMessageQueueSettings settings, string caller, Action<TMessage> handler) where TMessage : class
    {
        _channelFactory.UseChannel(settings, channel =>
        {
            var exchangeName = ExchangeNameGenerator.GenerateExchangeName<TMessage>();
            var queueName = caller;
            
            channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            channel.QueueDeclare(queueName, true);
            channel.QueueBind(queueName, exchangeName, "");
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (modell, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var model = JsonSerializer.Deserialize<TMessage>(message);

                handler(model!);
            };

            channel.BasicConsume(queueName, true, consumer);
        });
    }

    public void OnMessage<TMessage>(IMessageQueueSettings settings, string caller, Func<TMessage, Task> handler) where TMessage : class
    {
        _channelFactory.UseChannel(settings, channel =>
        {
            var exchangeName = ExchangeNameGenerator.GenerateExchangeName<TMessage>();
            var queueName = caller;
            
            channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, autoDelete: false);
            channel.QueueDeclare(queueName, autoDelete: false, durable: true);
            channel.QueueBind(queueName, exchangeName, "");
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (modell, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var model = JsonSerializer.Deserialize<TMessage>(message);

                await handler(model!);
            };

            channel.BasicConsume(queueName, true, consumer);
        });
    }
}