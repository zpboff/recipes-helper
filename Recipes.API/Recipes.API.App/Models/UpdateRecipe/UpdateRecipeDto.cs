using Recipes.API.App.Models.CreateRecipe;
using Recipes.API.App.Models.Entities;

namespace Recipes.API.App.Models.UpdateRecipe;

public class UpdateRecipeDto
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public IEnumerable<IngredientCreateDto> Ingredients { get; set; } = null!;
    public IEnumerable<RecipeStepCreateDto> Steps { get; set; } = null!;
    public bool IsDeleted { get; set; }
    
    public RecipeEntity ToRecipe(string userId)
    {
        return new RecipeEntity
        {
            Id = Id,
            Description = Description,
            Title = Title,
            IsDeleted = IsDeleted,
            UserId = userId,
            PreviewImage = PreviewImage,
            Ingredients = Ingredients.Select(i => i.ToIngredient()),
            Steps = Steps.Select(s => s.ToStep())
        };
    }
}