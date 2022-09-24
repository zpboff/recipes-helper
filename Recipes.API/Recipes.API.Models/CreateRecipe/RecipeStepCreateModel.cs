namespace Recipes.API.Models.CreateRecipe;

public class RecipeStepCreateModel
{
    public int Order { get; set; }
    public string Content { get; set; } = null!;
    public string? Image { get; set; }
}