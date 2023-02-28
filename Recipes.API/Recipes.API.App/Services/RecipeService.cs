using Core.MessageBus.Public;
using Core.Models;
using FluentValidation;
using Recipes.API.App.Extensions;
using Recipes.API.App.Models.CreateRecipe;
using Recipes.API.App.Models.Entities;
using Recipes.API.App.Models.UpdateRecipe;
using Recipes.API.App.Repositories;
using Recipes.API.App.Settings;
using Recipes.API.Models.Shared;

namespace Recipes.API.App.Services;

public class RecipeService : IRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IValidator<CreateRecipeDto> _createRecipeValidator;
    private readonly IValidator<UpdateRecipeDto> _updateRecipeValidator;

    public RecipeService(IMessageProducer messageProducer, RecipesMessageBusSettings settings,
        IValidator<CreateRecipeDto> createRecipeValidator, IRecipeRepository recipeRepository,
        IValidator<UpdateRecipeDto> updateRecipeValidator)
    {
        _createRecipeValidator = createRecipeValidator;
        _recipeRepository = recipeRepository;
        _updateRecipeValidator = updateRecipeValidator;
        _messageProducer = messageProducer.Initialize(settings);
    }

    public async Task<OperationResult<string>> CreateRecipe(CreateRecipeDto dto, string userId,
        CancellationToken ct = default)
    {
        var validationResult = await _createRecipeValidator.ValidateAsync(dto, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToErrorsDictionary();
            return OperationResult<string>.None(OperationStatus.BadRequest, errors);
        }

        var recipe = dto.ToRecipe(userId);

        var now = DateTime.Now;

        recipe.Created = now;
        recipe.Updated = now;

        var result = await _recipeRepository.Save(recipe, ct);

        return HandleRecipeResult(result, recipe);
    }

    public async Task<OperationResult<string>> UpdateRecipe(UpdateRecipeDto dto, string userId,
        CancellationToken ct = default)
    {
        var validationResult = await _updateRecipeValidator.ValidateAsync(dto, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToErrorsDictionary();
            return OperationResult<string>.None(OperationStatus.BadRequest, errors);
        }

        var existingRecipe = await GetRecipe(dto.Id, ct);

        if (!existingRecipe.IsValid)
        {
            return OperationResult<string>.None(existingRecipe.Status, existingRecipe.Errors);
        }

        var recipe = dto.ToRecipe(userId);
        recipe.Updated = DateTime.Now;

        var result = await _recipeRepository.Update(recipe, ct);
        
        return HandleRecipeResult(result, recipe);
    }

    public async Task<OperationResult<RecipeReadDto>> GetRecipe(string id, CancellationToken ct)
    {
        var recipe = await _recipeRepository.Get(id, ct);

        return recipe.IsValid
            ? OperationResult<RecipeReadDto>.None(OperationStatus.BadRequest, recipe.Errors)
            : OperationResult<RecipeReadDto>.Some(recipe.Value!.ToRecipeReadDto());
    }

    private OperationResult<string> HandleRecipeResult(Maybe<string> id, RecipeEntity recipe)
    {
        if (!id.IsValid)
        {
            return OperationResult<string>.None(OperationStatus.InternalError);
        }
        
        var readDto = recipe.ToRecipeReadDto();
        _messageProducer.Produce(readDto);
        
        return OperationResult<string>.Some(id.Value!);
    }
}