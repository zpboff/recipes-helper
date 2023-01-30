namespace Core.MessageQueue.Public;

public interface IMessageConsumer 
{
    public void OnMessage<TMessage>(IMessageQueueSettings settings, string caller, Action<TMessage> handler) where TMessage: class;
    public void OnMessage<TMessage>(IMessageQueueSettings settings, string caller, Func<TMessage, Task> handler) where TMessage: class;
}