namespace Recipes.API.Models;

public class RecipeIdentityResponse
{
    public RecipeIdentityResponse(string? id)
    {
        Id = id;
    }

    public string? Id { get; set; }
}