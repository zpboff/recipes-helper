namespace Recipes.API.Models.CreateRecipe;

public class CreateRecipeRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PreviewImage { get; set; }
    public IEnumerable<IngredientCreateModel> Ingredients { get; set; }
    public IEnumerable<RecipeStepCreateModel> Steps { get; set; }
}