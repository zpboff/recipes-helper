using Microsoft.AspNetCore.Mvc;
using Recipes.Indexer.Models;

namespace Recipes.Search.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;

    public SearchController(ILogger<SearchController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    [HttpGet]
    public IEnumerable<RecipeDocument> Search()
    {
        return Enumerable.Range(1, 5).Select(_ => new RecipeDocument
            {
                Id = Guid.NewGuid().ToString()
            })
            .ToArray();
    }
}