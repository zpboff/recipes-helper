using RabbitMQ.Client;

namespace Core.MessageBus.RabbitMQ;

public class BusConnection: IDisposable
{
    public BusConnection(IConnection connection, IModel channel)
    {
        Connection = connection;
        Channel = channel;
    }

    private IConnection Connection { get; }
    public IModel Channel { get; }

    public void Dispose()
    {
        Channel.Close();
        Connection.Close();
    }
}