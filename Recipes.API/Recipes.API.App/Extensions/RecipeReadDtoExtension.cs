using Recipes.API.App.Models.Entities;
using Recipes.API.Models.Shared;

namespace Recipes.API.App.Extensions;

public static class RecipeReadDtoExtension
{
    public static RecipeReadDto ToRecipeReadDto(this RecipeEntity recipeEntity)
    {
        return new RecipeReadDto
        {
            Id = recipeEntity.Id,
            Description = recipeEntity.Description,
            Ingredients = recipeEntity.Ingredients.Select(i => i.ToIngredientReadDto()),
            Steps = recipeEntity.Steps.Select(s => s.ToStepReadDto()),
            Title = recipeEntity.Title,
            UserId = recipeEntity.UserId,
            PreviewImage = recipeEntity.PreviewImage
        };
    }

    private static StepReadDto ToStepReadDto(this StepEntity stepEntity)
    {
        return new StepReadDto
        {
            Content = stepEntity.Content,
            Image = stepEntity.Image,
            Order = stepEntity.Order
        };
    }
    
    private static IngredientReadDto ToIngredientReadDto(this IngredientEntity ingredientEntity)
    {
        return new IngredientReadDto
        {
            Count = ingredientEntity.Count,
            Measurement = ingredientEntity.Measurement,
            Name = ingredientEntity.Name
        };
    }
}