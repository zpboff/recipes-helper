import React from 'react';
import { Box, Button, Card, Flex, Heading, Link, Text, TextField } from "@radix-ui/themes";
import styles from "./login-form.module.css";

type Props = {
    
};

const LoginForm: React.FC<Props> = ({}) => {
    return (
        <Card size="4" variant="surface" className={styles.form}>
            <Heading mb="4">Вход</Heading>
            <Box pb="4">
                <Text as="label" >
                    <Text as="div" weight="medium" mb="1">Email</Text>
                    <TextField.Root value={""} onChange={console.log} />
                </Text>
            </Box>
            <Box pb="4">
                <Flex justify="between" pb="1" align="center">
                    <Text as="label" weight="medium">Пароль</Text>
                    <Link href="#">Забыли пароль?</Link>
                </Flex>                            
                <TextField.Root value={""} onChange={console.log} />
            </Box>
            <Flex justify="between" gap="3" align="start">
                <Link size="3" href="#">Зарегистрироваться</Link>
                <Button size="3" onClick={console.log}>Войти</Button>
            </Flex>
        </Card>
    )
}

export { LoginForm }