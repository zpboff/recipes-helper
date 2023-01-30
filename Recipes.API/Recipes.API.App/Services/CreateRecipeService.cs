using Core.MessageQueue.Public;
using Core.MongoDb;
using Mapster;
using MongoDB.Driver;
using Recipes.API.App.Settings;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.Shared.Entities.Recipe;
using Recipes.API.Models.Shared.Messages;

namespace Recipes.API.App.Services;

public class CreateRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IMongoCollection<Recipe> _collection;
    private readonly RecipesMessageQueueSettings _settings;

    public CreateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IMessageProducer messageProducer, RecipesMessageQueueSettings settings)
    {
        _messageProducer = messageProducer;
        _settings = settings;
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<string?> CreateRecipe(CreateRecipeRequest request, string userId)
    {
        var recipe = request.Adapt<Recipe>();

        recipe.Id = Guid.NewGuid().ToString();
        recipe.UserId = userId;

        //await _collection.InsertOneAsync(recipe);
        _messageProducer.Produce(_settings, new RecipeMessage
        {
            Recipe = recipe
        });

        return recipe.Id;
    }
}