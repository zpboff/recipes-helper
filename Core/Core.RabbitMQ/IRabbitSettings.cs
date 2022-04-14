using Core.Settings;

namespace Core.RabbitMQ;

public interface IRabbitSettings: ISettings
{
    string Host { get; set; }
    string User { get; set; }
    string Password { get; set; }
}