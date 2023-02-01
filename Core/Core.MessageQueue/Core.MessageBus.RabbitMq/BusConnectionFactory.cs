using Core.MessageBus.Public;
using RabbitMQ.Client;

namespace Core.MessageBus.RabbitMQ;

public class BusConnectionFactory: IBusChannelFactory
{
    public BusConnection CreateConnection(IMessageBusSettings settings)
    {
        var factory = new ConnectionFactory
        {
            HostName = settings.Host,
            UserName = settings.User,
            Password = settings.Password
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        return new BusConnection(connection, channel);
    }
}