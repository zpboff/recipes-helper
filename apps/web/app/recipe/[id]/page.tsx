import { PageLayout } from '@/layouts/page-layout/ui';
import { Box } from '@radix-ui/themes';
import { Heading } from '@radix-ui/themes';
import axios from 'axios';
import React from 'react';
import { cache } from 'react'

async function loadRecipe(id: string): Promise<Recipe> {
    console.log('loadRecipe')
    const { data } = await axios.get<Recipe>(`https://api.spoonacular.com/recipes/${id}/information`, {
        params: {
            apiKey: process.env.SPOONACULAR_API_KEY
        }
    });
    return data;
}

const cachedLoadRecipe = cache(loadRecipe);

export async function generateMetadata({ params: { id } }: any) {
    const { title } = await cachedLoadRecipe(id);

    return {
      title: `${title} - recipes-helper`,
    }
}

type Recipe = {
    id: string;
    title: string;
}

type Props = {
    params: {
        id: string;
    }
}

const Recipe: React.FC<Props> = async ({ params: { id } }) => {
    const { title } = await cachedLoadRecipe(id);

    return (
        <PageLayout>
            <Box height="100%">
                <Heading>{title}</Heading>
            </Box>      
        </PageLayout>  
    )
}

export default Recipe;