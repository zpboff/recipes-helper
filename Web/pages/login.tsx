import {Field} from 'formik';
import type {NextPage} from 'next';
import Head from 'next/head';
import React from "react";
import { Content } from '../components/Content';
import {Form} from '../components/Form';
import {BaseLayout} from '../components/Layouts';
import {Seo} from '../components/Seo';
import type {NextPageWithLayout} from './_app';

type LoginParams = {
    email: string;
    password: string;
    stayLoggedIn: boolean;
}

const Login: NextPageWithLayout = () => {
    return (
        <>
            <Seo title="Вход"/>
            <Content>
                <Form<LoginParams>
                    defaultValues={{
                        email: "",
                        password: "",
                        stayLoggedIn: false
                    }}
                    onSubmit={console.log}
                >
                    <label htmlFor="email">Email</label>
                    <Field id="email" name="email" placeholder="Email"/>
    
                    <label htmlFor="password">Password</label>
                    <Field id="password" name="password" placeholder="password"/>
    
                    <label htmlFor="stayLoggedIn">Stay Logged In</label>
                    <Field id="stayLoggedIn" name="stayLoggedIn" type="checkbox"/>
    
                    <button type="submit">Submit</button>
                </Form>
            </Content>
        </>
    );
};

Login.getLayout = function getLayout(page: React.ReactElement) {
    return <BaseLayout>{page}</BaseLayout>;
}

export default Login;