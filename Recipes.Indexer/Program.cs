using Core.RabbitMQ;
using Core.Settings;
using MassTransit;
using Recipes.Indexer.Settings;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureServices((context, services) =>
    {
        services.RegisterConfiguration(context.Configuration);
        services.AddRabbit<RecipesIndexerRabbitSettings>(configurator =>
        {
            configurator.AddDelayedMessageScheduler();
        });
    })
    .Build();

await host.RunAsync();