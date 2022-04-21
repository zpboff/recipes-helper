using Core.Elastic;
using Core.Settings;
using Recipes.Search.Api.Services;

namespace Recipes.Search.Api;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterConfiguration(configuration)
            .AddElastic();
    
        services.AddTransient<RecipesSearchService>();
        
        return services;
    }
}