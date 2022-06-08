using Core.RabbitMQ;
using Core.Settings;
using MassTransit;
using Recipes.Indexer;
using Recipes.Indexer.Settings;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.RegisterConfiguration(context.Configuration);
        services.AddTransient<RecipesIndexer>();
        services.AddRabbit(configurator =>
        {
            configurator.AddDelayedMessageScheduler();
        });
    })
    .Build();

var settings = host.Services.GetService<RecipesIndexerRabbitSettings>();
var busFactory = host.Services.GetService<RabbitBusFactory>();
var bus = busFactory!.CreateBus(settings.Host, settings.User, settings.Password);

try
{
    await bus.StartAsync();
}
finally
{    
    await bus.StopAsync();
}
