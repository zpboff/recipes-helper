using Core.Utilities;
using Recipes.API.Models.Entities;

namespace Recipes.API.App.Repositories;

public interface IRecipeRepository
{
    public Task<Maybe<string>> Save(Recipe recipe, CancellationToken ct = default);
    public Task<Maybe<string>> Update(Recipe recipe, CancellationToken ct = default);
}