using Identity.Contracts;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.Models.CreateRecipe;

namespace TempClient.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IAuthorizedApiProvider _apiProvider;
    private readonly TempClientSettings _settings;
    
    public HomeController(IAuthorizedApiProvider apiProvider, TempClientSettings settings)
    {
        _apiProvider = apiProvider;
        _settings = settings;
    }

    [Route("[action]")]
    public async Task Get()
    {
        await _apiProvider.PostRequestAsync<CreateRecipeResponse, CreateRecipeRequest>(_settings.IdentityServerUrl,
            $"{_settings.ApiUrl}/create-recipe", new CreateRecipeRequest
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
    }
}