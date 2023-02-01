using Core.MessageBus.Public;
using Microsoft.Extensions.DependencyInjection;

namespace Core.MessageBus.RabbitMQ;

public static class RabbitMqDi
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services)
    {
        services.AddTransient<IBusChannelFactory, BusConnectionFactory>();
        services.AddTransient<IMessageProducer, MessageProducer>();
        services.AddTransient<IMessageConsumer, MessageConsumer>();
        
        return services;
    }
}