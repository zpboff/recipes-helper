using FluentValidation;
using Recipes.API.App.Repositories;
using Recipes.API.App.Services;
using Recipes.API.App.Validators;

namespace Recipes.API.App;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInternalServices(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateRecipeRequestValidator>()
            .AddScoped<IRecipeService, RecipeService>()
            .AddScoped<IRecipeRepository, RecipeRepository>();
        
        return services;
    }
}