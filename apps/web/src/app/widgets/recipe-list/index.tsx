import React, { useEffect, useState } from 'react';
import { Grid } from "@radix-ui/themes"
import { Recipe, RecipeCard } from "@/app/features/recipe-card"
import axios from 'axios';

type Props = {
    
};

type Response = {
    recipes: Recipe[];
}

async function loadRecipes() {
    const { data: { recipes } } = await axios.get<Response>("https://api.spoonacular.com/recipes/random", {
        params: {
            apiKey: process.env.RECIPES_API_KEY,
            number: 9
        }
    });

    return recipes;
}

const RecipeList: React.FC<Props> = async ({}) => {
    const recipes = await loadRecipes();

    return (
        <Grid columns="3" gap="3" width="auto" pb="6">
            {recipes.map(recipe => (
                <RecipeCard key={recipe.id} recipe={recipe} />
            ))}
        </Grid>
    )
}

export { RecipeList }