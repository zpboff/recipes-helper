import type {NextPage} from 'next';
import Head from "next/head";
import React from "react";
import { BaseLayout } from '../components/Layouts';
import { Seo } from '../components/Seo';
import { NextPageWithLayout } from './_app';
import {Field} from "formik";
import NavLink from 'next/link';
import { Link } from '../components/Link';
import styles from './AuthPages.module.css';
import { Form } from '../components/Form';
import {LockIcon, MailIcon } from '../components/Icons';
import { Input } from '../components/Input';
import { Button } from '../components/Button';
import { Checkbox } from '../components/Checkbox';

type RegisterParams = {
    email: string;
    password: string;
}

const Register: NextPageWithLayout = () => {
    return (
        <div className={styles.page}>
            <Seo title="Регистрация" />
            <Form<RegisterParams>
                defaultValues={{
                    email: "",
                    password: ""
                }}
                onSubmit={console.log}
                className={styles.form}
            >
                <section className={styles.head}>
                    <h2>Регистрация</h2>
                    <span className={styles.note}>Введите данные для регистрации в системе</span>
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
                    Зарегистрироваться
                </Button>
            </Form>
            <section className={styles.additionalBlock}>
                <div className={styles.relinking}>
                    <span className={styles.note}>Есть учетная запись?</span>
                    {" "}
                    <NavLink href="/login">
                        <Link>
                            Войти
                        </Link>
                    </NavLink>
                </div>
            </section>
        </div>
    );
};

Register.getLayout = function getLayout(page: React.ReactElement) {
    return <BaseLayout>{page}</BaseLayout>;
}

export default Register;