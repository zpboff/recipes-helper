namespace Recipes.API.Models.Shared;

public class RecipeReadDto
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public string UserId { get; set; } = null!;
    public IEnumerable<IngredientReadDto> Ingredients { get; set; } = null!;
    public IEnumerable<StepReadDto> Steps { get; set; } = null!;
}