using Microsoft.AspNetCore.Mvc;
using Recipe.Search.Shared;
using Recipes.Search.Api.Services;

namespace Recipes.Search.Api.Controllers.V1;

[ApiController]
public class SearchController : ControllerBase
{
    private readonly RecipesSearchService _searchService;

    public SearchController(RecipesSearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    [Route("api/v1/[controller]/{query}")]
    public async Task<IEnumerable<RecipeSearchReadDto>> Index(string query, int from, int size)
    {
        var items = await _searchService.Search(query, from, size);

        return items.Select(RecipeSearchReadDto.FromRecipeDocument);
    }
}