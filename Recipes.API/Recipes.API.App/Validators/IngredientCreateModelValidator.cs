using FastEndpoints.Validation;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class IngredientCreateModelValidator : Validator<IngredientCreateModel>
{
    public IngredientCreateModelValidator()
    {
        
        RuleFor(s => s.Name).NotEmpty().WithMessage("Введите наименование продукта");
        RuleFor(s => s.Count).GreaterThan(0).WithMessage("Введите количество");
        RuleFor(s => s.Measurement).NotEmpty().WithMessage("Укажите ед.изм");
    }
}