using FluentValidation;
using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Validators;

public class UpdateRecipeRequestValidator : AbstractValidator<UpdateRecipeDto>
{
    public UpdateRecipeRequestValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("Укажите идентификатор рецепта");
        RuleFor(s => s.Title).NotEmpty().WithMessage("Введите название рецепта");
        RuleFor(s => s.Ingredients).NotEmpty().WithMessage("Укажите ингриенты");
        RuleFor(s => s.Steps).NotEmpty().WithMessage("Заполните этапы приготовления");
    }
}