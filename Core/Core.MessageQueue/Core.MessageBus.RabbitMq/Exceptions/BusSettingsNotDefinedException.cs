namespace Core.MessageBus.RabbitMQ.Exceptions;

public class BusSettingsNotDefinedException: Exception
{
    public BusSettingsNotDefinedException(string message) : base(message)
    {
        
    }
}