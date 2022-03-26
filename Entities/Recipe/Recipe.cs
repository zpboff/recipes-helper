namespace Entities.Recipe
{
    public class Recipe: IEntity
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PreviewImage { get; set; } = null!;
        public IEnumerable<Ingredient> Ingredients { get; set; } = null!;
        public IEnumerable<Step> Steps { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}