using Core.MongoDb;
using Entities;
using FastEndpoints;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Settings;

namespace Recipes.API.Endpoints;

public class CreateRecipeEndpoint: Endpoint<CreateRecipeRequest, CreateRecipeResponse>
{
    private readonly IMongoCollection<Recipe> _collection;
    
    public CreateRecipeEndpoint(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings)
    {
        _collection = mongoFactory.GetDataBase(mongoSettings.ConnectionString, mongoSettings.Database)
            .GetCollection<Recipe>(mongoSettings.CollectionName);
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Post();
        Routes("/create-recipe");
    }

    public override async Task HandleAsync(CreateRecipeRequest req, CancellationToken ct)
    {
        var recipe = new Recipe
        {
            Id = Guid.NewGuid().ToString()
        };
        
        await _collection.InsertOneAsync(recipe, cancellationToken: ct);

        await SendAsync(new CreateRecipeResponse
        {   
            Id = recipe.Id
        }, cancellation: ct);
    }
}