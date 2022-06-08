using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Mapper;

public static class MapperDI
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        var assembly = Assembly.GetEntryAssembly();
        
        var profiles = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IMappingProfile)));
                
        foreach (var profileType in profiles)
        {
            var profile = (IMappingProfile)Activator.CreateInstance(profileType)!;
            profile.Register(config);
        }

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        
        return services;
    }
}