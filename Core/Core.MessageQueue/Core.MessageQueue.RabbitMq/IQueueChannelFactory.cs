using Core.MessageQueue.Public;
using RabbitMQ.Client;

namespace Core.MessageQueue.RabbitMQ;

public interface IQueueChannelFactory
{
    void UseChannel(IMessageQueueSettings settings, Action<IModel> action);
}