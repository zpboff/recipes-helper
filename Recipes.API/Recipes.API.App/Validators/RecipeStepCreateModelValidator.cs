using FluentValidation;
using Recipes.API.App.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class RecipeStepCreateModelValidator : AbstractValidator<RecipeStepCreateDto>
{
    public RecipeStepCreateModelValidator()
    {
        RuleFor(s => s.Content).NotEmpty()
            .WithMessage("Заполните описание")
            .OverridePropertyName("content");
    }
}