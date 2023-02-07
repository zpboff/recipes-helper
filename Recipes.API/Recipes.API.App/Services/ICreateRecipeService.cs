using Core.Utilities;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Services;

public interface ICreateRecipeService
{
    Task<Maybe<string>> CreateRecipe(CreateRecipeDto dto, string userId, CancellationToken ct = default);
}