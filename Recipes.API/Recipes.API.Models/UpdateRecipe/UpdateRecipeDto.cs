using Recipes.API.Models.CreateRecipe;
using Recipes.API.Models.Entities;

namespace Recipes.API.Models.UpdateRecipe;

public class UpdateRecipeDto
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public IEnumerable<IngredientCreateDto> Ingredients { get; set; } = null!;
    public IEnumerable<RecipeStepCreateDto> Steps { get; set; } = null!;
    public bool IsDeleted { get; set; }
    
    public Recipe ToRecipe(string userId)
    {
        return new Recipe
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