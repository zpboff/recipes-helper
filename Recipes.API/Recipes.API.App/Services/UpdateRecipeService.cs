using Core.MessageBus.Public;
using Core.MongoDb;
using Core.Utilities;
using FluentValidation;
using MongoDB.Driver;
using Recipes.API.App.Extensions;
using Recipes.API.App.Settings;
using Recipes.API.Models.Entities;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public class UpdateRecipeService: IUpdateRecipeService
{
    private readonly IValidator<UpdateRecipeDto> _updateRecipeValidator;
    private readonly IMessageProducer _messageProducer;
    private readonly IMongoCollection<Recipe> _collection;

    public UpdateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IMessageProducer messageProducer, RecipesMessageBusSettings settings, 
        IValidator<UpdateRecipeDto> updateRecipeValidator)
    {
        _updateRecipeValidator = updateRecipeValidator;
        _messageProducer = messageProducer.Initialize(settings);
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<Maybe<string>> UpdateRecipe(UpdateRecipeDto dto, string userId, CancellationToken ct = default)
    {
        var validationResult = await _updateRecipeValidator.ValidateAsync(dto, ct);
        
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToErrorsDictionary();
            return Maybe<string>.None(errors);
        }
        
        var filter = Builders<Recipe>.Filter.And(
            Builders<Recipe>.Filter.Eq(r => r.Id, dto.Id),
            Builders<Recipe>.Filter.Eq(r => r.UserId, userId)
        );

        var recipe = dto.ToRecipe(userId);

        var result = await _collection.ReplaceOneAsync(filter, recipe, cancellationToken: ct);

        if (!result.IsAcknowledged)
        {
            return Maybe<string>.None("Внутренняя ошибка приложения");
        }

        var message = recipe.ToRecipeReadDto();
        
        _messageProducer.Produce(message);

        return Maybe<string>.Some(recipe.Id);

    }
}