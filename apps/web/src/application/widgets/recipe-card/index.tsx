import React from 'react';
import { Box, Card, Inset, Text, Strong } from "@radix-ui/themes";
import Link from 'next/link';
import Image from 'next/image';
import { Recipe } from '@/domain/models/recipe/model';

type Props = {
    recipe: Recipe;
};

const RecipeCard: React.FC<Props> = ({ recipe }) => {
    return (
        <Box maxWidth="240px">
            <Link href={`/recipe/${recipe.id}`}>
                <Card size="2">
                    <Inset clip="padding-box" side="top" pb="current">
                    <Image
                        src={recipe.image}
                        width={240}
                        height={140}
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
            </Link>
        </Box>
    )
}

export { RecipeCard }