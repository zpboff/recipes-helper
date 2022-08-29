using Core.MongoDb;
using Mapster;
using MassTransit;
using MongoDB.Driver;
using Recipes.API.App.Settings;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.Shared.Entities.Recipe;
using Recipes.API.Models.Shared.Messages;

namespace Recipes.API.App.Services;

public class CreateRecipeService
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMongoCollection<Recipe> _collection;

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