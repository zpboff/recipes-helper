import React from 'react';
import { Grid } from "@radix-ui/themes"
import { ProductCard } from "@/app/features/product-card"

type Props = {
    
};

const ProductList: React.FC<Props> = ({}) => {
    return (
        <Grid columns="3" gap="3" width="auto">
            <ProductCard />
            <ProductCard />
            <ProductCard />
            <ProductCard />
            <ProductCard />
            <ProductCard />
            <ProductCard />
            <ProductCard />
            <ProductCard />
        </Grid>
    )
}

export { ProductList }