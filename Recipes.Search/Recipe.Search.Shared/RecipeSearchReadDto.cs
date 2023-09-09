using Recipes.Indexer.Shared;

namespace Recipe.Search.Shared;

public class RecipeSearchReadDto
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string[]? Ingredients { get; set; }

    public static RecipeSearchReadDto FromRecipeDocument(RecipeDocument recipeDocument)
    {
        return new RecipeSearchReadDto
        {
            Id = recipeDocument.Id,
            Description = recipeDocument.Description,
            Ingredients = recipeDocument.Ingredients?.Select(i => i.Name).ToArray(),
            Title = recipeDocument.Title,
            UserId = recipeDocument.UserId
        };
    }
}