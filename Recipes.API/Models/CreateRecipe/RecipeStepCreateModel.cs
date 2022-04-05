namespace Recipes.API.Models.CreateRecipe;

public class RecipeStepCreateModel
{
    public int Index { get; set; }
    public string Content { get; set; } = null!;
    public IEnumerable<string>? Images { get; set; }
}

public class RecipeStepCreateModelValidator : Validator<RecipeStepCreateModel>
{
    public RecipeStepCreateModelValidator()
    {
        RuleFor(s => s.Content).NotEmpty().WithMessage("Заполните описание");
    }
}