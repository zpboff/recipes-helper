using Core.Models;
using Core.MongoDb;
using Core.Utilities;
using MongoDB.Driver;
using Recipes.API.App.Models.Entities;
using Recipes.API.App.Settings;

namespace Recipes.API.App.Repositories;

public class RecipeRepository: IRecipeRepository
{
    private readonly IMongoCollection<RecipeEntity> _collection;
    private readonly ILogger<RecipeRepository> _logger;

    public RecipeRepository(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings, ILogger<RecipeRepository> logger)
    {
        _logger = logger;
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<RecipeEntity>(mongoSettings.RecipesCollectionName);
    }

    public async Task<Maybe<string>> Save(RecipeEntity recipeEntity, CancellationToken ct = default)
    {
        try
        {
            var options = new InsertOneOptions
            {
                Comment = $"Recipe saving: {recipeEntity.Id}"
            };

            await _collection.InsertOneAsync(recipeEntity, options, ct);

            return Maybe<string>.Some(recipeEntity.Id);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Ошибка при сохранении рецепта {Id}", recipeEntity.Id);
            return Maybe<string>.None("Ошибка при обновлении рецепта");
        }
    }

    public async Task<Maybe<string>> Update(RecipeEntity recipeEntity, CancellationToken ct = default)
    {
        try
        {
            var filter = Builders<RecipeEntity>.Filter.And(
                Builders<RecipeEntity>.Filter.Eq(r => r.Id, recipeEntity.Id),
                Builders<RecipeEntity>.Filter.Eq(r => r.UserId, recipeEntity.UserId)
            );
            
            var result = await _collection.FindOneAndReplaceAsync(filter, recipeEntity, cancellationToken: ct);

            return result is null 
                ? Maybe<string>.None("Ошибка сохранения рецепта") 
                : Maybe<string>.Some(recipeEntity.Id);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Ошибка при сохранении рецепта {Id}", recipeEntity.Id);
            return Maybe<string>.None(ex.Message);
        }
    }

    public async Task<Maybe<RecipeEntity>> Get(string id, CancellationToken ct = default)
    {
        try
        {
            var filter = Builders<RecipeEntity>.Filter.Eq(r => r.Id, id);
            
            var cursor = await _collection.FindAsync(filter, cancellationToken: ct);

            var recipeEntity = await cursor.FirstAsync(ct);

            return recipeEntity is null
                ? Maybe<RecipeEntity>.None("Ошибка при получении рецепта") 
                : Maybe<RecipeEntity>.Some(recipeEntity);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении рецепта по {Id}", id);
            return Maybe<RecipeEntity>.None(ex.Message);
        }
    }
}