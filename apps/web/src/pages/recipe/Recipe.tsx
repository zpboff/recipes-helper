import { Box } from '@radix-ui/themes';
import { Heading } from '@radix-ui/themes';
import axios from 'axios';
import React from 'react';

type Recipe = {
    id: string;
    title: string;
}

async function loadRecipe(id: string): Promise<Recipe> {
    const { data } = await axios.get<Recipe>(`https://api.spoonacular.com/recipes/${id}/information`, {
        params: {
            apiKey: process.env.SPOONACULAR_API_KEY
        }
    });
    return data;
}

type Props = {
    params: {
        id: string;
    }
}

const Recipe: React.FC<Props> = async ({ params: { id } }) => {
    const { id: recipeId, title } = await loadRecipe(id);

    return (
        <Box>
            <Box>{recipeId}</Box>
            <Box>
                <Heading>{title}</Heading>
            </Box>
        </Box>
    )
}

export default Recipe;