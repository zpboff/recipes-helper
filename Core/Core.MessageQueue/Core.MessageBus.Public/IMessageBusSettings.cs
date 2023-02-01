using Core.Settings;

namespace Core.MessageBus.Public;

public interface IMessageBusSettings: ISettings
{
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}