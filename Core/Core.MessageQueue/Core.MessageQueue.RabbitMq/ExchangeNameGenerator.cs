namespace Core.MessageQueue.RabbitMQ;

public static class ExchangeNameGenerator
{
    public static string GenerateExchangeName<TMessage>() where TMessage : class
    {
        var messageType = typeof(TMessage);
        return $"{messageType.Namespace}:{messageType.Name}";
    }
}