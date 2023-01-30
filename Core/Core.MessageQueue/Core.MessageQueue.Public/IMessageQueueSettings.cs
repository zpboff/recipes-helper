using Core.Settings;

namespace Core.MessageQueue.Public;

public interface IMessageQueueSettings: ISettings
{
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}