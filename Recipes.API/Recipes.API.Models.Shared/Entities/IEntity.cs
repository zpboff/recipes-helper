namespace Recipes.API.Models.Shared.Entities;

public interface IEntity: IHasId
{
    public bool IsDeleted { get; set; }
}