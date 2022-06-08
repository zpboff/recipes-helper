using Core.Mapper;
using Mapster;
using Recipes.API.Models.Shared.Entities.Recipe;
using Recipes.Indexer.Models;

namespace Recipes.Indexer.Service.Mappings;

public class RecipeToRecipeDocument: IMappingProfile
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Recipe, RecipeDocument>()
            .Map(dest => dest.Ingredients, src => src.Ingredients.Select(i => i.Name));
    }
}