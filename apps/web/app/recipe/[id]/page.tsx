import { PageLayout } from '@/application/layouts/page-layout';
import { recipeService } from '@/domain/services/RecipeService';
import { recipesRepository } from '@/infrastructure/repositories/recipes/recipesRepository';
import { Box } from '@radix-ui/themes';
import { Heading } from '@radix-ui/themes';
import { isNil } from 'lodash';
import React from 'react';
import { cache } from 'react';

const loadRecipe = async (id: string) => {
    const result = await recipeService.getRecipe(recipesRepository, id);

    return result.value;
}

const cachedLoadRecipe = cache(loadRecipe);

export async function generateMetadata({ params: { id } }: any) {
    const recipe = await cachedLoadRecipe(id);

    if(isNil(recipe)) {
        return null;
    }

    return {
      title: `${recipe.title} - recipes-helper`,
    }
}

type Props = {
    params: {
        id: string;
    }
}

const RecipePage: React.FC<Props> = async ({ params: { id } }) => {
    const recipe = await cachedLoadRecipe(id);

    if(isNil(recipe)) {
        return null;
    }

    return (
        <PageLayout>
            <Box height="100%">
                <Heading>{recipe.title}</Heading>
            </Box>      
        </PageLayout>  
    )
}

export default RecipePage;