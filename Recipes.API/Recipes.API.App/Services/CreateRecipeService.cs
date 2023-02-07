using Core.MessageBus.Public;
using Core.MongoDb;
using Core.Utilities;
using FluentValidation;
using MongoDB.Driver;
using Recipes.API.App.Extensions;
using Recipes.API.App.Settings;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.Entities;

namespace Recipes.API.App.Services;

public class CreateRecipeService : ICreateRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IMongoCollection<Recipe> _collection;
    private readonly IValidator<CreateRecipeDto> _createRecipeValidator;

    public CreateRecipeService(IMongoFactory mongoFactory, RecipesMongoSettings mongoSettings,
        IMessageProducer messageProducer, RecipesMessageBusSettings settings,
        IValidator<CreateRecipeDto> createRecipeValidator)
    {
        _createRecipeValidator = createRecipeValidator;
        _messageProducer = messageProducer.Initialize(settings);
        _collection = mongoFactory.GetDataBase(mongoSettings)
            .GetCollection<Recipe>(mongoSettings.RecipesCollectionName);
    }

    public async Task<Maybe<string>> CreateRecipe(CreateRecipeDto dto, string userId, CancellationToken ct = default)
    {
        var validationResult = await _createRecipeValidator.ValidateAsync(dto, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToErrorsDictionary();
            return Maybe<string>.None(errors);
        }
        
        var recipe = dto.ToRecipe(userId);

        await SaveRecipe(recipe, ct);

        var readDto = recipe.ToRecipeReadDto();
        _messageProducer.Produce(readDto);

        return Maybe<string>.Some(recipe.Id);
    }

    private async Task SaveRecipe(Recipe recipe, CancellationToken ct = default)
    {
        var options = new InsertOneOptions
        {
            Comment = $"Recipe saving: {recipe.Id}"
        };
        
        await _collection.InsertOneAsync(recipe, options, ct);
    }
}