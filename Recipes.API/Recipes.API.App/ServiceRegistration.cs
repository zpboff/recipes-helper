using FluentValidation;
using Recipes.API.App.Services;
using Recipes.API.App.Validators;

namespace Recipes.API.App;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInternalServices(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateRecipeRequestValidator>()
            .AddScoped<ICreateRecipeService, CreateRecipeService>()
            .AddScoped<IUpdateRecipeService, UpdateRecipeService>();
        
        return services;
    }
}