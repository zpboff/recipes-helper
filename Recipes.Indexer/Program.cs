using Core.RabbitMQ;
using MassTransit;
using Recipes.Indexer.Settings;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddRabbit(configurator =>
        {
            configurator.AddDelayedMessageScheduler();
            
            configurator.UsingRabbitMq((context, cfg) =>
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