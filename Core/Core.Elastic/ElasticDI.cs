using Microsoft.Extensions.DependencyInjection;

namespace Core.Elastic;

public static class ElasticDi
{
    public static IServiceCollection AddElastic(this IServiceCollection services)
    {
        services.AddTransient<IElasticClientFactory, ElasticClientFactory>();
        
        return services;
    }
}