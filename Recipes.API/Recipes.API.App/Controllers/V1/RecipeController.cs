using Microsoft.AspNetCore.Mvc;
using Recipes.API.App.Services;
using Recipes.API.Models;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Controllers.V1;

[Route("api/v1/[controller]/[action]")]
public class RecipeController : ControllerBase
{
    private readonly ICreateRecipeService _createRecipeService;
    private readonly IUpdateRecipeService _updateRecipeService;

    public RecipeController(ICreateRecipeService createRecipeService, IUpdateRecipeService updateRecipeService)
    {
        _createRecipeService = createRecipeService;
        _updateRecipeService = updateRecipeService;
    }

    [HttpPut]
    public async Task<IActionResult> CreateRecipe([FromBody]CreateRecipeDto req, CancellationToken ct)
    {
        var recipeIdResult = await _createRecipeService.CreateRecipe(req, "", ct);

        if (!recipeIdResult.IsValid)
        {   
            return BadRequest(recipeIdResult.Errors);
        }

        return Ok(new RecipeIdentityResponse(recipeIdResult.Value)); 
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRecipe(UpdateRecipeDto req, CancellationToken ct)
    {
        
        var recipeIdResult = await _updateRecipeService.UpdateRecipe(req, "", ct);

        if (!recipeIdResult.IsValid)
        {
            return BadRequest(recipeIdResult.Errors);
        }

        return Ok(new RecipeIdentityResponse(recipeIdResult.Value));
    }
}