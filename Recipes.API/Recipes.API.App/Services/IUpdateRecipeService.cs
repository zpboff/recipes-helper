using Recipes.API.App.Models;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public interface IUpdateRecipeService
{
    Task<OperationResult<string>> UpdateRecipe(UpdateRecipeDto dto, string userId, CancellationToken ct);
}