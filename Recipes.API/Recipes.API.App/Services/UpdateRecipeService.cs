using Core.MessageBus.Public;
using Core.MongoDb;
using MongoDB.Driver;
using Recipes.API.App.Extensions;
using Recipes.API.App.Settings;
using Recipes.API.Models.Entities;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public class UpdateRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IMongoCollection<Recipe> _collection;

    public UpdateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IMessageProducer messageProducer, RecipesMessageBusSettings settings)
    {
        _messageProducer = messageProducer.Initialize(settings);
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<string?> UpdateRecipe(UpdateRecipeDto dto, string userId)
    {
        var filter = Builders<Recipe>.Filter.And(
            Builders<Recipe>.Filter.Eq(r => r.Id, dto.Id),
            Builders<Recipe>.Filter.Eq(r => r.UserId, userId)
        );

        var recipe = dto.ToRecipe(userId);

        var result = await _collection.ReplaceOneAsync(filter, recipe);

        if (!result.IsAcknowledged)
        {
            return null;
        }

        var message = recipe.ToRecipeReadDto();
        
        _messageProducer.Produce(message);

        return recipe.Id;

    }
}