using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Settings
{
    public static class HostBuilderConfiguration
    {
        public static IServiceCollection RegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetEntryAssembly();

            var settings = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ISettings)));
                
            foreach (var setting in settings)
            {
                services.AddSingleton(setting, configuration.GetSection(setting.Name).Get(setting));
            }
            
            return services;
        }
    }
}