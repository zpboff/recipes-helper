namespace Core.MessageBus.Public;

public interface IMessageConsumer: IDisposable
{
    public IMessageConsumer Initialize(IMessageBusSettings settings);
    public void OnMessage<TMessage>(string caller, Func<TMessage, Task> handler) where TMessage: class;
}