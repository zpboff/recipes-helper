namespace Core.MessageBus.RabbitMQ.Exceptions;

public class BusConnectionClosedException: Exception
{
    public BusConnectionClosedException(string message) : base(message)
    {
        
    }
}