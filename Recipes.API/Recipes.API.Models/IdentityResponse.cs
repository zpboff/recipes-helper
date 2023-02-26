namespace Recipes.API.Models;

public class IdentityResponse
{
    public IdentityResponse(string? id)
    {
        Id = id;
    }

    public string? Id { get; set; }
}