using Core.Elastic;
using Core.Mapper;
using Core.RabbitMQ;
using Core.Settings;
using MassTransit;
using Recipes.Indexer.Mappings;
using Recipes.Indexer.Settings;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureServices((context, services) =>
    {
        services
            .RegisterConfiguration(context.Configuration)
            .AddMapper(config =>
            {
                config.RegisterRecipeToRecipeDocument();
            })
            .AddElastic()
            .AddRabbit<RecipesIndexerRabbitSettings>(configurator => { configurator.AddDelayedMessageScheduler(); });
    })
    .Build();

await host.RunAsync();