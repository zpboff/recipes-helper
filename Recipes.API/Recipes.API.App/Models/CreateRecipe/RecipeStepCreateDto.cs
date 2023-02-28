using Recipes.API.App.Models.Entities;

namespace Recipes.API.App.Models.CreateRecipe;

public class RecipeStepCreateDto
{
    public int Order { get; set; }
    public string Content { get; set; } = null!;
    public string? Image { get; set; }

    public StepEntity ToStep()
    {
        return new StepEntity
        {
            Id = Guid.NewGuid().ToString(),
            Content = Content,
            Image = Image,
            Order = Order
        };
    }
}