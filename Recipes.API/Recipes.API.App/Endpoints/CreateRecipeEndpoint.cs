﻿using FastEndpoints;
using Recipes.API.App.Services;
using Recipes.API.Models;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Endpoints;

public class CreateRecipeEndpoint: Endpoint<CreateRecipeRequest, RecipeIdentityResponse>
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

        await SendAsync(new RecipeIdentityResponse
        {   
            Id = recipeId
        }, cancellation: ct);
    }
}