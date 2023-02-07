using Core.MessageBus.Public;
using Core.Utilities;
using FluentValidation;
using Recipes.API.App.Extensions;
using Recipes.API.App.Repositories;
using Recipes.API.App.Settings;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Services;

public class UpdateRecipeService: IUpdateRecipeService
{
    private readonly IValidator<UpdateRecipeDto> _updateRecipeValidator;
    private readonly IMessageProducer _messageProducer;
    private readonly IRecipeRepository _recipeRepository;

    public UpdateRecipeService(IMessageProducer messageProducer, RecipesMessageBusSettings settings, 
        IValidator<UpdateRecipeDto> updateRecipeValidator, IRecipeRepository recipeRepository)
    {
        _updateRecipeValidator = updateRecipeValidator;
        _recipeRepository = recipeRepository;
        _messageProducer = messageProducer.Initialize(settings);
    }

    public async Task<Maybe<string>> UpdateRecipe(UpdateRecipeDto dto, string userId, CancellationToken ct = default)
    {
        var validationResult = await _updateRecipeValidator.ValidateAsync(dto, ct);
        
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToErrorsDictionary();
            return Maybe<string>.None(errors);
        }

        var recipe = dto.ToRecipe(userId);

        var result = await _recipeRepository.Update(recipe, ct);

        if (result.IsValid)
        {
            var message = recipe.ToRecipeReadDto();
        
            _messageProducer.Produce(message);
        }

        return result;
    }
}