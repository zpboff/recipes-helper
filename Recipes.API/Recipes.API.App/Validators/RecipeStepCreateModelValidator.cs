using FluentValidation;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class RecipeStepCreateModelValidator : AbstractValidator<RecipeStepCreateDto>
{
    public RecipeStepCreateModelValidator()
    {
        RuleFor(s => s.Content).NotEmpty().WithMessage("Заполните описание");
    }
}