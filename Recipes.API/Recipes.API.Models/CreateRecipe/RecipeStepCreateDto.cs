using Recipes.API.Models.Shared.Entities.Recipe;

namespace Recipes.API.Models.CreateRecipe;

public class RecipeStepCreateDto
{
    public int Order { get; set; }
    public string Content { get; set; } = null!;
    public string? Image { get; set; }

    public Step ToStep()
    {
        return new Step
        {
            Id = Guid.NewGuid().ToString(),
            Content = Content,
            Image = Image,
            Order = Order
        };
    }
}