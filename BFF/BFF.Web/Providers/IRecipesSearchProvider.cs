using Recipes.API.Models.Shared;

namespace BFF.Web.Providers;

public interface IRecipesSearchProvider
{
    Task<IEnumerable<RecipeReadDto>?> Search(string query);
}