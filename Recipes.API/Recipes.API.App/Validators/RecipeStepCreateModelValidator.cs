using FastEndpoints.Validation;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class RecipeStepCreateModelValidator : Validator<RecipeStepCreateModel>
{
    public RecipeStepCreateModelValidator()
    {
        RuleFor(s => s.Content).NotEmpty().WithMessage("Заполните описание");
    }
}