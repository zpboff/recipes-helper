using FluentValidation;
using Recipes.API.App.Models.CreateRecipe;

namespace Recipes.API.App.Validators;

public class CreateRecipeRequestValidator : AbstractValidator<CreateRecipeDto>
{
    public CreateRecipeRequestValidator()
    {
        RuleFor(s => s.Title).NotEmpty()
            .WithMessage("Введите название рецепта")
            .OverridePropertyName("title");
        
        RuleFor(s => s.Ingredients).NotEmpty()
            .WithMessage("Укажите ингриенты")
            .OverridePropertyName("ingredients");
        
        RuleFor(s => s.Steps).NotEmpty()
            .WithMessage("Заполните этапы приготовления")
            .OverridePropertyName("stteps");
    }
}