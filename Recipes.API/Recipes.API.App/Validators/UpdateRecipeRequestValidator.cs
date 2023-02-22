using FluentValidation;
using Recipes.API.Models.UpdateRecipe;

namespace Recipes.API.App.Validators;

public class UpdateRecipeRequestValidator : AbstractValidator<UpdateRecipeDto>
{
    public UpdateRecipeRequestValidator()
    {
        RuleFor(s => s.Id).NotEmpty()
            .WithMessage("Укажите идентификатор рецепта")
            .OverridePropertyName("id");
        
        RuleFor(s => s.Title).NotEmpty()
            .WithMessage("Введите название рецепта")
            .OverridePropertyName("title");
        
        RuleFor(s => s.Ingredients).NotEmpty()
            .WithMessage("Укажите ингриенты")
            .OverridePropertyName("ingredients");
        
        RuleFor(s => s.Steps).NotEmpty()
            .WithMessage("Заполните этапы приготовления")
            .OverridePropertyName("steps");
    }
}