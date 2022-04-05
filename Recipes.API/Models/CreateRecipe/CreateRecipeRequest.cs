namespace Recipes.API.Models.CreateRecipe;

public class CreateRecipeRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PreviewImage { get; set; }
    public IEnumerable<IngredientCreateModel> Ingredients { get; set; }
    public IEnumerable<RecipeStepCreateModel> Steps { get; set; }
}

public class CreateRecipeRequestValidator : Validator<CreateRecipeRequest>
{
    public CreateRecipeRequestValidator()
    {
        RuleFor(s => s.Title).NotEmpty().WithMessage("Введите название рецепта");
        RuleFor(s => s.Ingredients).NotEmpty().WithMessage("Укажите ингриенты");
        RuleFor(s => s.Steps).NotEmpty().WithMessage("Заполните этапы приготовления");
    }
}