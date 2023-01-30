namespace Core.MessageQueue.Public;

public interface IMessageProducer
{
    void Produce<T>(IMessageQueueSettings settings, T message) where T : class, new();
}