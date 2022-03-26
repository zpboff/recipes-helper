namespace Entities;

public interface IEntity: IHasId
{
    public bool IsDeleted { get; set; }
}