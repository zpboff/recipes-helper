import { AspectRatio, Avatar, Box, Card, Flex, Grid, Inset, Strong, Text } from '@radix-ui/themes';
import React from 'react';

type Props = {
    
};

const CategoryList: React.FC<Props> = ({}) => {
    return (
        <Grid columns="3" pb="4">
            <Box maxWidth="240px">
                <Card size="2" style={{ paddingBottom: 0}}> 
                    <Inset clip="padding-box" side="top" style={{ position: "relative", zIndex: -1 }}>
                        <AspectRatio ratio={3 / 2}>
                            <img
                                src="https://images.unsplash.com/photo-1617050318658-a9a3175e34cb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=600&q=80"
                                alt="Bold typography"
                                style={{
                                display: 'block',
                                objectFit: 'cover',
                                width: '100%',
                                backgroundColor: 'var(--gray-5)',
                                }}
                            />
                        </AspectRatio>
                    </Inset>
                    <Text style={{ position: "absolute", bottom: 0, padding: "8px", color: "white" }} highContrast>
                        <Strong>Завтраки</Strong>
                    </Text>
                </Card>
            </Box>
        </Grid>
    )
}

export { CategoryList }