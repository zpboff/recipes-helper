using Core.MessageQueue.Public;
using Core.MongoDb;
using Mapster;
using MongoDB.Driver;
using Recipes.API.App.Settings;
using Recipes.API.Models.Shared.Entities.Recipe;
using Recipes.API.Models.Shared.Messages;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public class UpdateRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IMongoCollection<Recipe> _collection;
    private readonly RecipesMessageQueueSettings _settings;

    public UpdateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IMessageProducer messageProducer, RecipesMessageQueueSettings settings)
    {
        _messageProducer = messageProducer;
        _settings = settings;
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
        
        _messageProducer.Produce(_settings, new RecipeMessage
        {
            Recipe = recipe
        });

        return recipe.Id;

    }
}