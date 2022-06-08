using Core.Elastic;
using Core.Mapper;
using Core.RabbitMQ;
using Core.Settings;
using MassTransit;
using Recipes.Indexer.Service.Settings;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureServices((context, services) =>
    {
        services
            .RegisterConfiguration(context.Configuration)
            .AddMapper()
            .AddElastic()
            .AddRabbit<RecipesIndexerRabbitSettings>(configurator => { configurator.AddDelayedMessageScheduler(); });
    })
    .Build();

await host.RunAsync();