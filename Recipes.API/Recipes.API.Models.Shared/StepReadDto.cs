namespace Recipes.API.Models.Shared;

public class StepReadDto
{
    public int Order { get; set; }
    public string Content { get; set; } = null!;
    public string? Image { get; set; }
}