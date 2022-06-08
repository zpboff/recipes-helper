import type {NextPage} from 'next';
import Head from 'next/head';
import React from "react";
import { BaseLayout } from '../components/Layouts';
import { Seo } from '../components/Seo';
import type { NextPageWithLayout } from './_app';

const Login: NextPageWithLayout = () => {   
    return (
        <>
            <Seo title="Вход" />
            123213
        </>
    );
};

Login.getLayout = function getLayout(page: React.ReactElement) {
    return <BaseLayout>{page}</BaseLayout>;
}

export default Login;