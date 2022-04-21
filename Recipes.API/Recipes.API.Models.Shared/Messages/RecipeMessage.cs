using Recipes.API.Models.Shared.Entities.Recipe;

namespace Recipes.API.Models.Shared.Messages;

public class RecipeMessage
{
    public Recipe Recipe { get; set; }
}