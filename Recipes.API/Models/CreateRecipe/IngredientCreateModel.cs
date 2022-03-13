namespace Recipes.API.Models.CreateRecipe;

public class IngredientCreateModel
{
    public string Name { get; set; }
    public float Count { get; set; }
    public string Measurement { get; set; }
}