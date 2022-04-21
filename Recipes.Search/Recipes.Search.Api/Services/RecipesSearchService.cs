using Recipes.Indexer.Models;

namespace Recipes.Search.Api.Services;

public class RecipesSearchService
{
    public Task<IEnumerable<RecipeDocument>> Search(string query)
    {
        var items = Enumerable.Range(1, 5).Select(_ => new RecipeDocument
        {
            Id = Guid.NewGuid().ToString()
        });
        
        return Task.FromResult(items);
    }
}