using Core.Models;
using Core.Utilities;
using Recipes.API.App.Models.Entities;

namespace Recipes.API.App.Repositories;

public interface IRecipeRepository
{
    public Task<Maybe<string>> Save(RecipeEntity recipeEntity, CancellationToken ct = default);
    public Task<Maybe<string>> Update(RecipeEntity recipeEntity, CancellationToken ct = default);
    public Task<Maybe<RecipeEntity>> Get(string id, CancellationToken ct = default);
}