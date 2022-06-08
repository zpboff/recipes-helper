import type {NextPage} from 'next';
import Head from "next/head";
import React from "react";
import { BaseLayout } from '../components/Layouts';
import { Seo } from '../components/Seo';
import { NextPageWithLayout } from './_app';

const Register: NextPageWithLayout = () => {
    return (
        <>
            <Seo title="Регистрация" />
        </>
    );
};

Register.getLayout = function getLayout(page: React.ReactElement) {
    return <BaseLayout>{page}</BaseLayout>;
}

export default Register;