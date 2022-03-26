namespace Entities.Recipe;

public class Step: IHasId
{
    public string Id { get; set; } = null!;
    public int Index { get; set; }
    public string Content { get; set; }
    public IEnumerable<string> Images { get; set; }
}