using Core.Utilities;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public interface IUpdateRecipeService
{
    Task<Maybe<string>> UpdateRecipe(UpdateRecipeDto dto, string userId, CancellationToken ct);
}