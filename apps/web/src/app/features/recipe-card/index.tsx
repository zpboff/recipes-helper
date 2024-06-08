import React from 'react';
import { Box, Card, Inset, Text, Strong } from "@radix-ui/themes";

type Props = {
    recipe: Recipe;
};

export type Recipe = {
    id: string;
    title: string;
    image: string;
};

const RecipeCard: React.FC<Props> = ({ recipe }) => {
    return (
        <Box maxWidth="240px">
            <Card size="2">
                <Inset clip="padding-box" side="top" pb="current">
                <img
                    src={recipe.image}
                    alt="Bold typography"
                    style={{
                    display: 'block',
                    objectFit: 'cover',
                    width: '100%',
                    height: 140,
                    backgroundColor: 'var(--gray-5)',
                    }}
                />
                </Inset>
                <Text as="p" size="3">{recipe.title}</Text>
            </Card>
        </Box>
    )
}

export { RecipeCard }