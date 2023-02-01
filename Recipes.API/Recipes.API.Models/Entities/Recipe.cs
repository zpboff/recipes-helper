using Core.Models;
using Recipes.API.Models.Shared.Entities.Recipe;

namespace Recipes.API.Models.Entities;

public class Recipe: IEntity
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; } = null!;
    public IEnumerable<Step> Steps { get; set; } = null!;
    public bool IsDeleted { get; set; }
}