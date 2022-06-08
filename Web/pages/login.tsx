import {Field} from 'formik';
import type {NextPage} from 'next';
import Head from 'next/head';
import React from "react";
import {Content} from '../components/Content';
import {Form} from '../components/Form';
import {BaseLayout} from '../components/Layouts';
import {Seo} from '../components/Seo';
import type {NextPageWithLayout} from './_app';
import styles from './AuthPages.module.css';
import { Input } from '../components/Input';
import {LockIcon, MailIcon } from '../components/Icons';
import { Button } from '../components/Button';
import NavLink from 'next/link';
import { Link } from '../components/Link';
import { Checkbox } from '../components/Checkbox';

type LoginParams = {
    email: string;
    password: string;
    stayLoggedIn: boolean;
}

const Login: NextPageWithLayout = () => {
    return (
        <div className={styles.page}>
            <Seo title="Вход"/>
            <Form<LoginParams>
                defaultValues={{
                    email: "",
                    password: "",
                    stayLoggedIn: false
                }}
                onSubmit={console.log}
                className={styles.form}
            >
                <section className={styles.head}>
                    <h2>Вход</h2>
                    <span className={styles.note}>Введите данные для входа в систему</span>                    
                </section>
                <Field id="email" name="email">
                    {({ field }: any) => (
                        <Input
                            icon={<MailIcon className={styles.icon} />}
                            iconPosition="left"
                            label="Email"
                            {...field}
                        />
                    )}
                </Field>
                <Field id="password" name="password">
                    {({ field }: any) => (
                        <Input
                            icon={<LockIcon className={styles.icon} />}
                            iconPosition="left"
                            label="Пароль"
                            {...field}
                        />
                    )}
                </Field>
                <Button type="submit" className={styles.submit}>
                    Войти
                </Button>
                <Field id="stayLoggedIn" name="stayLoggedIn">
                    {({ field }: any) => (
                        <Checkbox textPosition="right" {...field}>
                            Запомнить меня
                        </Checkbox>
                    )}
                </Field>
            </Form>
            <section className={styles.additionalBlock}>
                <div className={styles.relinking}>
                    <span className={styles.note}>Забыли пароль?</span>
                    {" "}
                    <NavLink href="/password-recover">
                        <Link>
                            Восстановить пароль
                        </Link>
                    </NavLink>
                </div>
                <div className={styles.relinking}>
                    <span className={styles.note}>Нет учетной записи?</span>
                    {" "}
                    <NavLink href="/register">
                        <Link>
                            Регистрация
                        </Link>
                    </NavLink>
                </div>
            </section>
        </div>
    );
};

Login.getLayout = function getLayout(page: React.ReactElement) {
    return <BaseLayout>{page}</BaseLayout>;
}

export default Login;