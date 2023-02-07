using Core.MongoDb;
using Core.Utilities;
using MongoDB.Driver;
using Recipes.API.App.Settings;
using Recipes.API.Models.Entities;

namespace Recipes.API.App.Repositories;

public class RecipeRepository: IRecipeRepository
{
    private readonly IMongoCollection<Recipe> _collection;
    private readonly ILogger<RecipeRepository> _logger;

    public RecipeRepository(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings, ILogger<RecipeRepository> logger)
    {
        _logger = logger;
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<Maybe<string>> Save(Recipe recipe, CancellationToken ct = default)
    {
        try
        {
            var options = new InsertOneOptions
            {
                Comment = $"Recipe saving: {recipe.Id}"
            };

            await _collection.InsertOneAsync(recipe, options, ct);

            return Maybe<string>.Some(recipe.Id);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return Maybe<string>.None("Ошибка при обновлении рецепта");
        }
    }

    public async Task<Maybe<string>> Update(Recipe recipe, CancellationToken ct = default)
    {
        try
        {
            var filter = Builders<Recipe>.Filter.And(
                Builders<Recipe>.Filter.Eq(r => r.Id, recipe.Id),
                Builders<Recipe>.Filter.Eq(r => r.UserId, recipe.UserId)
            );
            
            var result = await _collection.ReplaceOneAsync(filter, recipe, cancellationToken: ct);

            return !result.IsAcknowledged 
                ? Maybe<string>.None("Ошибка сохранения рецепта") 
                : Maybe<string>.Some(recipe.Id);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return Maybe<string>.None(ex.Message);
        }
    }
}