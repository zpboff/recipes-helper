using Core.MongoDb;
using Mapster;
using MassTransit;
using MongoDB.Driver;
using Recipes.API.App.Settings;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.Shared.Entities.Recipe;
using Recipes.API.Models.Shared.Messages;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public class UpdateRecipeService
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMongoCollection<Recipe> _collection;

    public UpdateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<string?> UpdateRecipe(UpdateRecipeRequest request, string userId)
    {
        var filter = Builders<Recipe>.Filter.And(
            Builders<Recipe>.Filter.Eq(r => r.Id, request.Id),
            Builders<Recipe>.Filter.Eq(r => r.UserId, userId)
        );

        var recipe = request.Adapt<Recipe>();

        var result = await _collection.ReplaceOneAsync(filter, recipe);

        if (!result.IsAcknowledged)
        {
            return null;
        }
        
        await _publishEndpoint.Publish(new RecipeMessage
        {
            Recipe = recipe
        });

        return recipe.Id;

    }
}