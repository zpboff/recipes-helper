namespace Core.MessageBus.RabbitMQ.Exceptions;

public class BusConnectionNotInitializedException: Exception
{
    public BusConnectionNotInitializedException(string message) : base(message)
    {
        
    }
}