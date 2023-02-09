using Core.Elastic;
using Recipes.Indexer.Shared;
using Recipes.Search.Api.Settings;

namespace Recipes.Search.Api.Services;

public class RecipesSearchService
{
    private readonly IElasticClientFactory _clientFactory;
    private readonly RecipesElasticSettings _elasticSettings;

    public RecipesSearchService(IElasticClientFactory clientFactory, RecipesElasticSettings elasticSettings)
    {
        _clientFactory = clientFactory;
        _elasticSettings = elasticSettings;
    }

    public async Task<IEnumerable<RecipeDocument>> Search(string query)
    {
        var client = _clientFactory.GetClient(_elasticSettings);

        var searchRes =
            await client.SearchAsync<RecipeDocument>(cr =>
                cr.Index(_elasticSettings.Index).Query(q => q.Match(s => s.Field(r => r.Title).Query(query))));

        return searchRes.Hits.Select(h => h.Source)!;
    }
}