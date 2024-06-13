"use client";

import { BaseLayout } from "@/layouts/baseLayout";
import { Box, Button, Card, Flex, Heading, Link, Text, TextField } from "@radix-ui/themes";
import styles from "./login.module.css";
import { useUnit } from "effector-react";
import { $email, $password, emailChanged, passwordChanged, submitted } from "@/features/auth/by-email/model";
import { ChangeEvent, useEffect } from "react";
import { useRouter } from "next/navigation";
import { $loggedIn } from "@/entities/identity/model/store";

export const metadata = {
    title: 'Вход - Подбор рецептов',
    description: 'Вход',
}

export default function Login() {
    const logedIn = useUnit($loggedIn)
    const [email, setEmail] = useUnit([$email, emailChanged]);
    const [password, setPassword] = useUnit([$password, passwordChanged]);
    const { push } = useRouter();

    const changeEmail = (event: ChangeEvent<HTMLInputElement>) => setEmail(event.target.value);
    const changePassword = (event: ChangeEvent<HTMLInputElement>) => setPassword(event.target.value);

    useEffect(() => {
        if(logedIn) {
            push("/")
        }
    }, [logedIn]);

    if(logedIn) {
        return null;
    }
    
    return (
        <BaseLayout>
            <Box className={styles.container}>
                <Flex align="center" justify="center" className={styles.formWrapper}>
                    <Card size="4" variant="surface" className={styles.form}>
                        <Heading mb="4">Вход</Heading>
                        <Box pb="4">
                            <Text as="label" >
                                <Text as="div" weight="medium" mb="1">Email</Text>
                                <TextField.Root value={email} onChange={changeEmail} />
                            </Text>
                        </Box>
                        <Box pb="4">
                            <Flex justify="between" pb="1" align="center">
                                <Text as="label" weight="medium">Пароль</Text>
                                <Link href="#">Забыли пароль?</Link>
                            </Flex>                            
                            <TextField.Root value={password} onChange={changePassword}  />
                        </Box>
                        <Flex justify="between" gap="3" align="start">
                            <Link size="3" href="#">Зарегистрироваться</Link>
                            <Button size="3" onClick={() => submitted()}>Войти</Button>
                        </Flex>
                    </Card>
                </Flex>
            </Box>
        </BaseLayout>
    );
}