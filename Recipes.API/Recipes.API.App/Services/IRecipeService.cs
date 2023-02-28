using Core.Models;
using Recipes.API.App.Models.CreateRecipe;
using Recipes.API.App.Models.UpdateRecipe;
using Recipes.API.Models.Shared;

namespace Recipes.API.App.Services;

public interface IRecipeService
{
    Task<OperationResult<string>> CreateRecipe(CreateRecipeDto dto, string userId, CancellationToken ct = default);
    Task<OperationResult<string>> UpdateRecipe(UpdateRecipeDto dto, string userId, CancellationToken ct);
    Task<OperationResult<RecipeReadDto>> GetRecipe(string id, CancellationToken ct);
}