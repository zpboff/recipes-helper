namespace Recipes.API.Models.Shared.Entities.Recipe;

public class Ingredient: IHasId
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public float Count { get; set; }
    public string Measurement { get; set; } = null!;
}