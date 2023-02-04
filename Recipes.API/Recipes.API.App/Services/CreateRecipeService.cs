using Core.MessageBus.Public;
using Core.MongoDb;
using MongoDB.Driver;
using Recipes.API.App.Extensions;
using Recipes.API.App.Settings;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.Entities;

namespace Recipes.API.App.Services;

public class CreateRecipeService: ICreateRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IMongoCollection<Recipe> _collection;

    public CreateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IMessageProducer messageProducer, RecipesMessageBusSettings settings)
    {
        _messageProducer = messageProducer.Initialize(settings);
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<string?> CreateRecipe(CreateRecipeDto dto, string userId)
    {
        var recipe = dto.ToRecipe(userId);

        await _collection.InsertOneAsync(recipe);

        var readDto = recipe.ToRecipeReadDto();
        _messageProducer.Produce(readDto);

        return recipe.Id;
    }
}