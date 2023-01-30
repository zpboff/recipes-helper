using Core.MessageQueue.Public;
using Microsoft.Extensions.DependencyInjection;

namespace Core.MessageQueue.RabbitMQ;

public static class RabbitMqDi
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services)
    {
        services.AddTransient<IQueueChannelFactory, QueueChannelFactory>();
        services.AddTransient<IMessageProducer, MessageProducer>();
        services.AddTransient<IMessageConsumer, MessageConsumer>();
        
        return services;
    }
}