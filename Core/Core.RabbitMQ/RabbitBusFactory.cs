using MassTransit;

namespace Core.RabbitMQ;

public class RabbitBusFactory
{
    public IBusControl CreateBus(string host, string user, string password, Action<IRabbitMqBusFactoryConfigurator>? configure = null)
    {
        var busFactory = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri($"rabbitmq://{host}"), h =>
            {
                h.Username(user);
                h.Password(password);
            });

            configure?.Invoke(cfg);
        });

        return busFactory;
    }
}