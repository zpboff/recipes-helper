namespace Recipes.API.Models.Shared;

public class IngredientReadDto
{
    public string Name { get; set; } = null!;
    public float Count { get; set; }
    public string Measurement { get; set; } = null!;
}