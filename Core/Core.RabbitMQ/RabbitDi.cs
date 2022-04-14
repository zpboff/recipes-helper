using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Core.RabbitMQ;

public static class RabbitDi
{
    public static IServiceCollection AddRabbit(this IServiceCollection services, Action<IBusRegistrationConfigurator>? configure = null)
    {
        services.AddMassTransit(configurator =>
        {
            configurator.SetKebabCaseEndpointNameFormatter();

            var entryAssembly = Assembly.GetEntryAssembly();

            configurator.AddConsumers(entryAssembly);

            configure?.Invoke(configurator);
        });
        
        services.AddTransient<RabbitBusFactory>();
        
        return services;
    }
}