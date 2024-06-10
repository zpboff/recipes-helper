import React from 'react';
import { DropdownMenu, Button } from "@radix-ui/themes"
import { IconMenu2 } from '@tabler/icons-react';

type Props = {
    
};

const CategoryList: React.FC<Props> = ({}) => {
    return (
        <DropdownMenu.Root>
            <DropdownMenu.Trigger>
                <Button variant="soft">
                    Категории
                    <IconMenu2 />
                </Button>
            </DropdownMenu.Trigger>
            <DropdownMenu.Content>
                <DropdownMenu.Item>Первое</DropdownMenu.Item>
                <DropdownMenu.Item>Вторые блюда</DropdownMenu.Item>
            </DropdownMenu.Content>
        </DropdownMenu.Root>
    )
}

export { CategoryList }