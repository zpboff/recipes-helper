using Core.Mapper;
using Entities.Recipe;
using Mapster;
using Recipes.Indexer.Models;

namespace Recipes.Indexer.Mappings;

public class RecipeToRecipeDocument: IMappingProfile
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Recipe, RecipeDocument>()
            .Map(dest => dest.Ingredients, src => src.Ingredients.Select(i => i.Name));
    }
}