using Core.Settings;
using Identity.AppServices;
using Identity.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recipes.API.Models.CreateRecipe;
using TempClient;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => services
        .RegisterConfiguration(context.Configuration)
        .AddIdentityAppServices()
    )
    .Build();

var apiProvider = host.Services.GetRequiredService<IAuthorizedApiProvider>();
var settings = host.Services.GetRequiredService<TempClientSettings>();

await apiProvider.PostRequestAsync<CreateRecipeResponse, CreateRecipeRequest>(settings.IdentityServerUrl,
    $"{settings.ApiUrl}/create-recipe", new CreateRecipeRequest
    {
        Title = "Кимчи",
        Description = "Корейская закуска из капусты",
        Ingredients = new[]
        {
            new IngredientCreateModel
            {
                Name = "Пекинская капуста",
                Count = 1,
                Measurement = "шт."
            }
        },
        Steps = new[]
        {
            new RecipeStepCreateModel
            {
                Index = 1,
                Content = "Сделайте хорошо"
            }
        }
    });

await host.RunAsync();