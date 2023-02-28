using Core.Models;

namespace Recipes.API.App.Models.Entities;

public class IngredientEntity: IHasId
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public float Count { get; set; }
    public string Measurement { get; set; } = null!;
}