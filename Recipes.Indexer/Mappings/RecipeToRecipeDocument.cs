using Entities.Recipe;
using Mapster;
using Recipes.Indexer.Models;

namespace Recipes.Indexer.Mappings;

public static class RecipeToRecipeDocument
{
    public static void RegisterRecipeToRecipeDocument(this TypeAdapterConfig config)
    {
        config.NewConfig<Recipe, RecipeDocument>()
            .Map(dest => dest.Ingredients, src => src.Ingredients.Select(i => i.Name));
    }
}