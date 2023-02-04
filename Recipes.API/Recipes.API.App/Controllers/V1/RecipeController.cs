using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.App.Services;
using Recipes.API.Models;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Controllers.V1;

[Route("api/v1/[controller]/[action]")]
public class RecipeController : ControllerBase
{
    private readonly IValidator<CreateRecipeDto> _createRecipeValidator;
    private readonly IValidator<UpdateRecipeDto> _updateRecipeValidator;
    private readonly ICreateRecipeService _createRecipeService;
    private readonly IUpdateRecipeService _updateRecipeService;

    public RecipeController(ICreateRecipeService createRecipeService, IUpdateRecipeService updateRecipeService,
        IValidator<CreateRecipeDto> createRecipeValidator, IValidator<UpdateRecipeDto> updateRecipeValidator)
    {
        _createRecipeService = createRecipeService;
        _updateRecipeService = updateRecipeService;
        _createRecipeValidator = createRecipeValidator;
        _updateRecipeValidator = updateRecipeValidator;
    }

    [HttpPut]
    public async Task<IActionResult> CreateRecipe([FromBody]CreateRecipeDto req, CancellationToken ct)
    {
        var validationResult = await _createRecipeValidator.ValidateAsync(req, ct);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var recipeId = await _createRecipeService.CreateRecipe(req, "");

        return Ok(new RecipeIdentityResponse(recipeId));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRecipe(UpdateRecipeDto req, CancellationToken ct)
    {
        var validationResult = await _updateRecipeValidator.ValidateAsync(req, ct);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var recipeId = await _updateRecipeService.UpdateRecipe(req, "");

        return Ok(new RecipeIdentityResponse(recipeId));
    }
}