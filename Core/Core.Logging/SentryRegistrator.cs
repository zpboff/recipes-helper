using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Sentry;

namespace Core.Logging;

public static class SentryRegistrar
{
    public static IWebHostBuilder UseConfiguredSentry(this IWebHostBuilder builder)
    {
        builder.UseSentry(ConfigureSentry);

        return builder;
    }

    private static void ConfigureSentry(WebHostBuilderContext context, SentryOptions options)
    {
        options.Debug = true;
        options.TracesSampleRate = 1.0;
    }
}