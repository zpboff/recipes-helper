import { BaseLayout } from "@/layouts/baseLayout";
import { Box, Button, Card, Flex, Heading, Link, Text, TextField } from "@radix-ui/themes";
import styles from "./styles.module.css";

export default function Login() {    
    return (
        <BaseLayout>
            <Box className={styles.container}>
                <Flex align="center" justify="center" className={styles.formWrapper}>
                    <Card size="4" variant="surface" className={styles.form}>
                        <Heading mb="4">Вход</Heading>
                        <Box pb="4">
                            <Text as="label" >
                                <Text as="div" weight="medium" mb="1">Email</Text>
                                <TextField.Root />
                            </Text>
                        </Box>
                        <Box pb="4">
                            <Flex justify="between" pb="1" align="center">
                                <Text as="label" weight="medium">Пароль</Text>
                                <Link href="#">Забыли пароль?</Link>
                            </Flex>                            
                            <TextField.Root />
                        </Box>
                        <Flex justify="between" gap="3" align="start">
                            <Link size="3" href="#">Зарегистрироваться</Link>
                            <Button size="3">Войти</Button>
                        </Flex>
                    </Card>
                </Flex>
            </Box>
        </BaseLayout>
    );
}