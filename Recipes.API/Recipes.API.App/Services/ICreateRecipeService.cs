using Recipes.API.App.Models;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Services;

public interface ICreateRecipeService
{
    Task<OperationResult<string>> CreateRecipe(CreateRecipeDto dto, string userId, CancellationToken ct = default);
}