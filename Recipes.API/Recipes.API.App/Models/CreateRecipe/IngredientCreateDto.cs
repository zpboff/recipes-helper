using Recipes.API.App.Models.Entities;

namespace Recipes.API.App.Models.CreateRecipe;

public class IngredientCreateDto
{
    public string Name { get; set; } = null!;
    public float Count { get; set; }
    public string Measurement { get; set; } = null!;

    public IngredientEntity ToIngredient()
    {
        return new IngredientEntity
        {
            Id = Guid.NewGuid().ToString(),
            Count = Count,
            Measurement = Measurement,
            Name = Name
        };
    }
}