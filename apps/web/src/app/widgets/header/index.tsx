import React from 'react';
import styles from './styles.module.scss';
import {Flex, Button, TextField, Box } from "@radix-ui/themes";
import { CategoryList } from '../category-list';

export function Header() {
    return (
        <Flex className={styles.header}  as="div" direction="row" gap="3" justify="between" align="center">
                <CategoryList />
                <TextField.Root placeholder="Поиск" size="3" className={styles.searchBlock} />
                <Flex as='div' direction="row" gap="1">
                    <Button size="3">Вход</Button>
                    <Button size="3">Регистрация</Button>
                </Flex>                
            </Flex>
    );
}
