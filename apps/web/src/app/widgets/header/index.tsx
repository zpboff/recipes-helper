import React from 'react';
import styles from './styles.module.scss';
import {Flex, Button, TextField } from "@radix-ui/themes";

export function Header() {
    return (
        <Flex className={styles.header}  as="div" direction="row" gap="3" justify="between" align="center">
                <div>LOGO</div>
                <TextField.Root placeholder="Поиск" size="3" className={styles.searchBlock} />
                <Flex as='div' direction="row" gap="1">
                    <Button size="3">Войти</Button>
                    <Button size="3">Регистрация</Button>
                </Flex>                
            </Flex>
    );
}
