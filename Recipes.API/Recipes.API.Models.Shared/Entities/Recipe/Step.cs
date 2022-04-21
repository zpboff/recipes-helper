namespace Recipes.API.Models.Shared.Entities.Recipe;

public class Step
{   
    public string Id { get; set; } = null!;
    public int Index { get; set; }
    public string Content { get; set; }
    public IEnumerable<string> Images { get; set; }
}