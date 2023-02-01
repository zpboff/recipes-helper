namespace Core.Models;

public interface IEntity: IHasId
{
    public bool IsDeleted { get; set; }
}