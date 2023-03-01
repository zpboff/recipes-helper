namespace Core.Models;

public class IdentityResult: IHasId
{
    public IdentityResult(string? id)
    {
        Id = id;
    }

    public string? Id { get; set; }
}