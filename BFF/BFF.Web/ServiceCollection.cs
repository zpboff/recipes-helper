using BFF.Web.Providers;

namespace BFF.Web;

public static class ServiceCollection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IRecipesSearchProvider, RecipesSearchProvider>();

        return services;
    }
}