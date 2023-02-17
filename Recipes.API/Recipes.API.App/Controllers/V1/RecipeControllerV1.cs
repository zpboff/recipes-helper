using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.App.Services;
using Recipes.API.Models;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Controllers.V1;

[Route("api/v1/[controller]/[action]")]
public class RecipeControllerV1 : ControllerBase
{
    private readonly ILogger<RecipeControllerV1> _logger;
    private readonly ICreateRecipeService _createRecipeService;
    private readonly IUpdateRecipeService _updateRecipeService;

    public RecipeControllerV1(ICreateRecipeService createRecipeService, IUpdateRecipeService updateRecipeService,
        ILogger<RecipeControllerV1> logger)
    {
        _createRecipeService = createRecipeService;
        _updateRecipeService = updateRecipeService;
        _logger = logger;
    }

    [HttpPut]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDto req, CancellationToken ct)
    {
        var recipeIdResult = await _createRecipeService.CreateRecipe(req, "", ct);

        if (recipeIdResult.IsValid)
        {
            return Ok(new RecipeIdentityResponse(recipeIdResult.Value));
        }
        
        _logger.LogWarning("Плохой запрос {Request}", JsonSerializer.Serialize(req));
        
        return BadRequest(recipeIdResult.Errors);

    }

    [HttpPost]
    public async Task<IActionResult> UpdateRecipe(UpdateRecipeDto req, CancellationToken ct)
    {
        var recipeIdResult = await _updateRecipeService.UpdateRecipe(req, "", ct);

        if (recipeIdResult.IsValid)
        {
            return Ok(new RecipeIdentityResponse(recipeIdResult.Value));
        }
        
        _logger.LogWarning("Плохой запрос {Request}", JsonSerializer.Serialize(req));
        
        return BadRequest(recipeIdResult.Errors);

    }
}