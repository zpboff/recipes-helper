using Core.MessageQueue.Public;
using Core.Utilities;
using RabbitMQ.Client;

namespace Core.MessageQueue.RabbitMQ;

public class MessageProducer: IMessageProducer
{
    private readonly IQueueChannelFactory _channelFactory;

    public MessageProducer(IQueueChannelFactory channelFactory)
    {
        _channelFactory = channelFactory;
    }

    public void Produce<TMessage>(IMessageQueueSettings settings, TMessage message) where TMessage: class, new()
    {
        _channelFactory.UseChannel(settings, channel =>
        {
            var exchangeName = ExchangeNameGenerator.GenerateExchangeName<TMessage>();
            channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, autoDelete: false);
            
            channel.BasicPublish(exchangeName, "", null, ObjectToByteArrayConverter.Convert(message));
        });
    }
}