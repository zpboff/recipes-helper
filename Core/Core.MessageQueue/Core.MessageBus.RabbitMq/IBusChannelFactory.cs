using Core.MessageBus.Public;
using RabbitMQ.Client;

namespace Core.MessageBus.RabbitMQ;

public interface IBusChannelFactory
{
    BusConnection CreateConnection(IMessageBusSettings settings);
}