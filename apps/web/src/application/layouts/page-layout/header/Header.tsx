import React from 'react';
import styles from './header.module.css';
import {Flex, TextField } from "@radix-ui/themes";
import { IdentityLinks } from './IdentityLinks';
import { CategoryList } from '@/layouts/page-layout/header/category-list';

export function Header() {
    return (
        <Flex className={styles.header}  as="div" direction="row" gap="3" justify="between" align="center">
                <CategoryList />
                <TextField.Root placeholder="Поиск" size="3" className={styles.searchBlock} />
                <Flex as='div' direction="row" gap="1">
                    <IdentityLinks />                    
                </Flex>                
            </Flex>
    );
}
