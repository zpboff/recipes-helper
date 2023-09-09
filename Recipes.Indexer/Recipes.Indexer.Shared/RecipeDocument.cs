using Recipes.API.Models.Shared;

namespace Recipes.Indexer.Shared;

public class RecipeDocument
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public RecipeDocumentIngredient[]? Ingredients { get; set; }

    public static RecipeDocument FromRecipeReadDto(RecipeReadDto recipe)
    {
        return new RecipeDocument
        {
            Id = recipe.Id,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(RecipeDocumentIngredient.FromIngredient).ToArray(),
            Title = recipe.Title,
            UserId = recipe.UserId
        };
    }
}