using Recipes.API.Models.Entities;
using Recipes.API.Models.Shared;
using Recipes.API.Models.Shared.Entities.Recipe;

namespace Recipes.API.App.Extensions;

public static class RecipeReadDtoExtension
{
    public static RecipeReadDto ToRecipeReadDto(this Recipe recipe)
    {
        return new RecipeReadDto
        {
            Id = recipe.Id,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(i => i.ToIngredientReadDto()),
            Steps = recipe.Steps.Select(s => s.ToStepReadDto()),
            Title = recipe.Title,
            UserId = recipe.UserId,
            PreviewImage = recipe.PreviewImage
        };
    }

    private static StepReadDto ToStepReadDto(this Step step)
    {
        return new StepReadDto
        {
            Content = step.Content,
            Image = step.Image,
            Order = step.Order
        };
    }
    
    private static IngredientReadDto ToIngredientReadDto(this Ingredient ingredient)
    {
        return new IngredientReadDto
        {
            Count = ingredient.Count,
            Measurement = ingredient.Measurement,
            Name = ingredient.Name
        };
    }
}