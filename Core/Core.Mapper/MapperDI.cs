using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Mapper;

public static class MapperDI
{
    public static IServiceCollection AddMapper(this IServiceCollection services, Action<TypeAdapterConfig>? registerMappings = null)
    {
        var config = new TypeAdapterConfig();

        registerMappings?.Invoke(config);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        
        return services;
    }
}