using System.Reflection;
using Core.Settings;
using MassTransit;
using Recipes.Indexer;
using Recipes.Indexer.Settings;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.AddDelayedMessageScheduler();
            var entryAssembly = Assembly.GetEntryAssembly();
            x.AddConsumers(entryAssembly);
            
            x.UsingRabbitMq((context, cfg) =>
            {
                var settings = context.GetService<RecipesIndexerRabbitSettings>();
                
                cfg.Host(new Uri(settings!.Host), hostConf =>
                {
                    hostConf.Username(settings.User);
                    hostConf.Password(settings.Password);
                });
                
                cfg.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();