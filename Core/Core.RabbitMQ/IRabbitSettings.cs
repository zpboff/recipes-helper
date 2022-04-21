using Core.Settings;

namespace Core.RabbitMQ;

public interface IRabbitSettings: ISettings
{
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}