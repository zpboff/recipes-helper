using Recipes.Search.Api.Services;

namespace Recipes.Search.Api;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<RecipesSearchService>();
        
        return services;
    }
}