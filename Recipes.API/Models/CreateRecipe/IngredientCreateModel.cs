namespace Recipes.API.Models.CreateRecipe;

public class IngredientCreateModel
{
    public string Name { get; set; } = null!;
    public float Count { get; set; }
    public string Measurement { get; set; } = null!;
}

public class IngredientCreateModelValidator : Validator<IngredientCreateModel>
{
    public IngredientCreateModelValidator()
    {
        
        RuleFor(s => s.Name).NotEmpty().WithMessage("Введите наименование продукта");
        RuleFor(s => s.Count).GreaterThan(0).WithMessage("Введите количество");
        RuleFor(s => s.Measurement).NotEmpty().WithMessage("Укажите ед.изм");
    }
}