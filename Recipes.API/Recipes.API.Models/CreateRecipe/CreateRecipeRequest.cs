namespace Recipes.API.Models.CreateRecipe;

public class CreateRecipeRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public IEnumerable<IngredientCreateModel> Ingredients { get; set; } = null!;
    public IEnumerable<RecipeStepCreateModel> Steps { get; set; } = null!;
}