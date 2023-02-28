using Core.Models;

namespace Recipes.API.App.Models.Entities;

public class RecipeEntity: IEntity
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public IEnumerable<IngredientEntity> Ingredients { get; set; } = null!;
    public IEnumerable<StepEntity> Steps { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool IsDeleted { get; set; }
}