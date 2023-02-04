using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public interface IUpdateRecipeService
{
    Task<string?> UpdateRecipe(UpdateRecipeDto dto, string userId);
}