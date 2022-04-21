using FastEndpoints;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Services;
using Microsoft.AspNetCore.Identity;

namespace Recipes.API.Endpoints;

public class CreateRecipeEndpoint: Endpoint<CreateRecipeRequest, CreateRecipeResponse>
{
    private readonly CreateRecipeService _createRecipeService;
    public CreateRecipeEndpoint(CreateRecipeService createRecipeService)
    {
        _createRecipeService = createRecipeService;
    }
    
    public override void Configure()
    {
        Post();
        Routes("/create-recipe");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRecipeRequest req, CancellationToken ct)
    {
        var recipeId = await _createRecipeService.CreateService(req, "");

        await SendAsync(new CreateRecipeResponse
        {   
            Id = recipeId
        }, cancellation: ct);
    }
}