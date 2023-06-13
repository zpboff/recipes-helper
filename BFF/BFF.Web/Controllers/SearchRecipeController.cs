using BFF.Web.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Web.Controllers;

[ApiController]
public class SearchRecipeController: ControllerBase
{
    private readonly IRecipesSearchProvider _searchProvider;

    public SearchRecipeController(IRecipesSearchProvider searchProvider)
    {
        _searchProvider = searchProvider;
    }

    [HttpGet]
    [Route("[controller]/{query}")]
    public async Task<IActionResult> Index(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return BadRequest();
        }
        
        var recipes = await _searchProvider.Search(query);

        return Ok(recipes);
    }
}