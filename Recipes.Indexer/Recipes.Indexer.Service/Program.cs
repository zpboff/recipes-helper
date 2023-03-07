using Core.Elastic;
using Core.Logging;
using Core.MessageBus.RabbitMQ;
using Core.Settings;
using Recipes.Indexer.Service;

var host = Host.CreateDefaultBuilder(args)
    .UseConfiguration()
    .UseLogging()
    .ConfigureServices(services =>
    {
        services.AddElastic()
            .AddRabbitMq()
            .AddHostedService<RecipesIndexer>();
    })
    .Build();

await host.RunAsync();