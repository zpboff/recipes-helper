namespace Recipes.Indexer.Models;

public class RecipeDocument
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string[] Ingredients { get; set; } = null!;
}