using Recipes.API.Models.Entities;

namespace Recipes.API.Models.CreateRecipe;

public class CreateRecipeDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PreviewImage { get; set; }
    public IEnumerable<IngredientCreateDto> Ingredients { get; set; } = null!;
    public IEnumerable<RecipeStepCreateDto> Steps { get; set; } = null!;

    public Recipe ToRecipe(string userId)
    {
        return new Recipe
        {
            Id = Guid.NewGuid().ToString(),
            Description = Description,
            Title = Title,
            IsDeleted = false,
            UserId = userId,
            PreviewImage = PreviewImage,
            Ingredients = Ingredients.Select(i => i.ToIngredient()),
            Steps = Steps.Select(s => s.ToStep())
        };
    }
}