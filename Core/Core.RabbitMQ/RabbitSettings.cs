namespace Core.RabbitMQ;

public class RabbitSettings: IRabbitSettings
{
    public string Host { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}