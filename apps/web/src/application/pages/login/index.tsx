"use client";

import React from 'react';
import { BaseLayout } from "@/application/layouts/baseLayout";
import { Box, Button, Card, Flex, Heading, Link, Text, TextField } from "@radix-ui/themes";
import styles from "./login.module.css";
import { LoginForm } from './login-form';
import { useRouter } from 'next/navigation';

type Props = {
    
};

const Login: React.FC<Props> = ({}) => {
    const { push } = useRouter();

    return (
        <BaseLayout>
            <Box className={styles.container}>
                <Flex align="center" justify="center" className={styles.formWrapper}>
                    <LoginForm />
                </Flex>
            </Box>
        </BaseLayout>
    )
}

export { Login }