import React, { useEffect, useState } from 'react';
import { Grid } from "@radix-ui/themes"
import { RecipeCard } from "@/application/widgets/recipe-card"
import { recipeService } from '@/domain/services/RecipeService';
import { recipesRepository } from '@/infrastructure/repositories/recipes/recipesRepository';

type Props = {
    
};



const RecipeList: React.FC<Props> = async ({}) => {
    const recipes = await recipeService.getRecipes(recipesRepository, 1);

    if(!recipes.hasValue) {
        return;
    }

    return (
        <Grid columns="3" gap="3" width="auto" pb="6">
            {recipes.value!.map(recipe => (
                <RecipeCard key={recipe.id} recipe={recipe} />
            ))}
        </Grid>
    )
}

export { RecipeList }