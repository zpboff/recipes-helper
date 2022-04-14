using MassTransit;

namespace Core.RabbitMQ;

public class RabbitBusFactory
{
    private readonly IRabbitSettings _settings;

    public RabbitBusFactory(IRabbitSettings settings)
    {
        _settings = settings;
    }
        
    public IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator>? configure)
    {
        var busFactory = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri($"rabbitmq://{_settings.Host}"), h =>
            {
                h.Username(_settings.User);
                h.Password(_settings.Password);
            });

            configure?.Invoke(cfg);
        });

        return busFactory;
    }
}