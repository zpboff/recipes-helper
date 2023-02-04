using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Services;

public interface ICreateRecipeService
{
    Task<string?> CreateRecipe(CreateRecipeDto dto, string userId);
}