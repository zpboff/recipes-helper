using Recipes.API.Models.Shared;

namespace Recipes.Indexer.Shared;

public class RecipeDocumentIngredient
{
    public string Name { get; set; }
    public float Count { get; set; }

    public static RecipeDocumentIngredient FromIngredient(IngredientReadDto ingredient)
    {
        return new RecipeDocumentIngredient
        {
            Count = ingredient.Count,
            Name = ingredient.Name
        };
    }
}