using System.Text.Json;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.App.Models.CreateRecipe;
using Recipes.API.App.Models.UpdateRecipe;
using Recipes.API.App.Services;
using Recipes.API.Models;

namespace Recipes.API.App.Controllers.V1;

[Route("api/v1/[controller]/[action]")]
public class RecipeControllerV1 : ControllerBase
{
    private readonly ILogger<RecipeControllerV1> _logger;
    private readonly IRecipeService _recipeService;

    public RecipeControllerV1(IRecipeService recipeService, ILogger<RecipeControllerV1> logger)
    {
        _recipeService = recipeService;
        _logger = logger;
    }

    [HttpPut]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDto req, CancellationToken ct)
    {
        var recipeIdResult = await _recipeService.CreateRecipe(req, "", ct);

        return ProcessResult(recipeIdResult, req);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRecipe([FromBody] UpdateRecipeDto req, CancellationToken ct)
    {
        var recipeIdResult = await _recipeService.UpdateRecipe(req, "", ct);
        
        return ProcessResult(recipeIdResult, req);
    }

    private IActionResult ProcessResult(OperationResult<string> result, object req)
    {
        switch (result.Status)
        {
            case OperationStatus.Ok:
                return Ok(new IdentityResponse(result.Value));
            case OperationStatus.InternalError:
                _logger.LogError("Ошибка выполнения {Request}", JsonSerializer.Serialize(req));
                return Problem(); 
            case OperationStatus.BadRequest:
                _logger.LogInformation("Плохой запрос {Request}", JsonSerializer.Serialize(req));
                return BadRequest(result.Errors);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}