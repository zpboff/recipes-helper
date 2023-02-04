﻿using FluentValidation;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class CreateRecipeRequestValidator : AbstractValidator<CreateRecipeDto>
{
    public CreateRecipeRequestValidator()
    {
        RuleFor(s => s.Title).NotEmpty().WithMessage("Введите название рецепта");
        RuleFor(s => s.Ingredients).NotEmpty().WithMessage("Укажите ингриенты");
        RuleFor(s => s.Steps).NotEmpty().WithMessage("Заполните этапы приготовления");
    }
}