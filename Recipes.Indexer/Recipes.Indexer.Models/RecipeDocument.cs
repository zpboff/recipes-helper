using Recipes.API.Models.Shared.Entities.Recipe;

namespace Recipes.Indexer.Models;

public class RecipeDocument
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string[]? Ingredients { get; set; }

    public static RecipeDocument FromRecipe(Recipe recipe)
    {
        return new RecipeDocument
        {
            Id = recipe.Id,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(i => i.Name).ToArray(),
            Title = recipe.Title,
            UserId = recipe.UserId
        };
    }
}