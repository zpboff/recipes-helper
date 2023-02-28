namespace Core.Models;

public interface IEntity: IHasId
{
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool IsDeleted { get; set; }
}