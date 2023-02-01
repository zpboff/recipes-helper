namespace Recipes.API.Models.Shared.Entities.Recipe;

public class Step
{   
    public string Id { get; set; } = null!;
    public int Order { get; set; }
    public string Content { get; set; } = null!;
    public string? Image { get; set; }
}