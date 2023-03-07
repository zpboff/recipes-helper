using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.Settings
{
    public static class HostBuilderConfiguration
    {
        public static IHostBuilder UseConfiguration(this IHostBuilder hostBuilder)
        {

            hostBuilder.ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.Logging.json", optional: true);
            });

            hostBuilder.ConfigureServices((context, services) =>
            {
                RegisterConfiguration(services, context.Configuration);
            });

            return hostBuilder;
        }
        
        private static void RegisterConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetEntryAssembly();

            if (assembly == null)
            {
                return;
            }
            
            var settings = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ISettings)));
            
            foreach (var setting in settings)
            {
                services.AddSingleton(setting, configuration.GetSection(setting.Name).Get(setting)!);
            }
        }
    }
}