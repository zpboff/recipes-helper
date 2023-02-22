using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Core.Logging;

public static class LoggingDi
{
    public static IHostBuilder UseLogging(this IHostBuilder hostBuilder)
    {
        Serilog.Debugging.SelfLog.Enable(Console.Error);
        hostBuilder.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration))
            .ConfigureLogging((c, l) =>
            {
                l.AddConfiguration(c.Configuration);
                l.AddSentry();
            });
        
        return hostBuilder;
    } 
}