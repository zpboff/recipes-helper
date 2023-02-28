namespace Recipes.API.App.Models.Entities;

public class StepEntity
{   
    public string Id { get; set; } = null!;
    public int Order { get; set; }
    public string Content { get; set; } = null!;
    public string? Image { get; set; }
}