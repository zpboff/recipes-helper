using Recipes.API.Models.Shared.Entities.Recipe;

namespace Recipes.API.Models.CreateRecipe;

public class IngredientCreateDto
{
    public string Name { get; set; } = null!;
    public float Count { get; set; }
    public string Measurement { get; set; } = null!;

    public Ingredient ToIngredient()
    {
        return new Ingredient
        {
            Id = Guid.NewGuid().ToString(),
            Count = Count,
            Measurement = Measurement,
            Name = Name
        };
    }
}