using Microsoft.AspNetCore.Mvc;
using Recipes.Indexer.Models;
using Recipes.Search.Api.Services;

namespace Recipes.Search.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;
    private readonly RecipesSearchService _searchService;

    public SearchController(ILogger<SearchController> logger, RecipesSearchService searchService)
    {
        _logger = logger;
        _searchService = searchService;
    }

    [Route("")]
    [HttpGet]
    public async Task<IEnumerable<RecipeDocument>> Search([FromQuery] string query)
    {
        return await _searchService.Search(query);
    }
}