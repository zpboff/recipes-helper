using Core.Elastic;
using Core.Logging;
using Core.MessageBus.RabbitMQ;
using Core.Settings;
using Recipes.Indexer.Service;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services
            .RegisterConfiguration(context.Configuration)
            .AddSerilogLogging(context.Configuration)
            .AddElastic()
            .AddRabbitMq()
            .AddHostedService<RecipesIndexer>();
    })
    .Build();

await host.RunAsync();