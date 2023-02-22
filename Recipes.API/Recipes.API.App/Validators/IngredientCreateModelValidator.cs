using FluentValidation;
using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class IngredientCreateModelValidator : AbstractValidator<IngredientCreateDto>
{
    public IngredientCreateModelValidator()
    {
        RuleFor(s => s.Name).NotEmpty()
            .WithMessage("Введите наименование продукта")
            .OverridePropertyName("name");
        
        RuleFor(s => s.Count).GreaterThan(0)
            .WithMessage("Введите количество")
            .OverridePropertyName("count");
        
        RuleFor(s => s.Measurement).NotEmpty()
            .WithMessage("Укажите ед.изм")
            .OverridePropertyName("measurement");
    }
}