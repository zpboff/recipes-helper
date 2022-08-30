using FastEndpoints;
using Recipes.API.App.Services;
using Recipes.API.Models;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Endpoints;

public class UpdateRecipeEndpoint: Endpoint<UpdateRecipeRequest, RecipeIdentityResponse>
{
    private readonly UpdateRecipeService _updateRecipeService;
    
    public UpdateRecipeEndpoint(UpdateRecipeService updateRecipeService)
    {
        _updateRecipeService = updateRecipeService;
    }
    
    public override void Configure()
    {
        Post();
        Routes("/update-recipe");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateRecipeRequest req, CancellationToken ct)
    {
        var recipeId = await _updateRecipeService.UpdateRecipe(req, "");

        await SendAsync(new RecipeIdentityResponse
        {   
            Id = recipeId
        }, cancellation: ct);
    }
}