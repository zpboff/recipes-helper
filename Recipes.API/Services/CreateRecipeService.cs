using Core.MongoDb;
using Entities.Recipe;
using Mapster;
using MassTransit;
using Messages;
using MongoDB.Driver;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Settings;

namespace Recipes.API.Services;

public class CreateRecipeService
{
    private readonly IMongoCollection<Recipe> _collection;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<string> CreateService(CreateRecipeRequest request, string userId)
    {
        var recipe = request.Adapt<Recipe>();

        recipe.Id = Guid.NewGuid().ToString();
        recipe.UserId = userId;

        await _collection.InsertOneAsync(recipe);
        await _publishEndpoint.Publish(new RecipeMessage
        {
            Recipe = recipe
        });

        return recipe.Id;
    }
}