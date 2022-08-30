using Recipes.API.Models.CreateRecipe;

namespace Recipes.API.Models.UpdateRecipe;

public class UpdateRecipeRequest: CreateRecipeRequest
{
    public string Id { get; set; }
}