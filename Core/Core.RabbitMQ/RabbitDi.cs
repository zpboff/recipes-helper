using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Core.RabbitMQ;

public static class RabbitDi
{
    public static IServiceCollection AddRabbit<T>(this IServiceCollection services, Action<IBusRegistrationConfigurator>? configure = null)
        where T: RabbitSettings
    {
        services.AddMassTransit(configurator =>
        {
            configurator.SetKebabCaseEndpointNameFormatter();

            var entryAssembly = Assembly.GetEntryAssembly();

            configurator.AddConsumers(entryAssembly);
            
            configurator.UsingRabbitMq((context,cfg) =>
            {
                var settings = context.GetRequiredService<T>();
                
                cfg.Host(settings.Host, hostConf =>
                {
                    hostConf.Username(settings.User);
                    hostConf.Password(settings.Password);
                });

                cfg.ConfigureEndpoints(context);
            });

            configure?.Invoke(configurator);
        });
        
        return services;
    }
}