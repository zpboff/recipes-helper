import type {NextPage} from 'next';
import Head from 'next/head';
import React from "react";
import { Seo } from '../components/Seo';

const Login: NextPage = () => {
    return (
        <>
            <Seo title="Вход" />
        </>
    );
};

export default Login;