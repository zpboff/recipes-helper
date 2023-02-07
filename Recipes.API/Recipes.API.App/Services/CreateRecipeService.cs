﻿using Core.MessageBus.Public;
using Core.Utilities;
using FluentValidation;
using Recipes.API.App.Extensions;
using Recipes.API.App.Repositories;
using Recipes.API.App.Settings;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Services;

public class CreateRecipeService : ICreateRecipeService
{
    private readonly IMessageProducer _messageProducer;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IValidator<CreateRecipeDto> _createRecipeValidator;

    public CreateRecipeService(IMessageProducer messageProducer, RecipesMessageBusSettings settings,
        IValidator<CreateRecipeDto> createRecipeValidator, IRecipeRepository recipeRepository)
    {
        _createRecipeValidator = createRecipeValidator;
        _recipeRepository = recipeRepository;
        _messageProducer = messageProducer.Initialize(settings);
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

        var result = await _recipeRepository.Save(recipe, ct);

        if (result.IsValid)
        {
            var readDto = recipe.ToRecipeReadDto();
            _messageProducer.Produce(readDto);
        }

        return result;
    }
}