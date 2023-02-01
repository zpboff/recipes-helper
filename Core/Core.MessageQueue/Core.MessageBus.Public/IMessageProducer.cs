namespace Core.MessageBus.Public;

public interface IMessageProducer
{
    public IMessageProducer Initialize(IMessageBusSettings settings);
    void Produce<T>(T message) where T : class, new();
}