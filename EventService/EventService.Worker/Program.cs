using Core.Logging;
using Core.MessageBus.RabbitMQ;
using Core.Settings;
using EventService.Worker;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateDefaultBuilder(args);

IHost host = builder
    .UseConfiguration()
    .UseLogging()
    .ConfigureServices((context, services) =>
    {
        services
            .AddRabbitMq()
            .AddDbContext<EventsDbContext>(options =>
            {
                options.UseNpgsql(context.Configuration.GetConnectionString("EventsSql"));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient)
            .AddTransient<EventsRepository>()
            .AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();