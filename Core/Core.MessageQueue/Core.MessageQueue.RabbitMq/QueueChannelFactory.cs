using Core.MessageQueue.Public;
using RabbitMQ.Client;

namespace Core.MessageQueue.RabbitMQ;

public class QueueChannelFactory: IQueueChannelFactory
{
    public void UseChannel(IMessageQueueSettings settings, Action<IModel> action)
    {
        var factory = new ConnectionFactory
        {
            HostName = settings.Host,
            UserName = settings.User,
            Password = settings.Password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        action(channel);
    }
}