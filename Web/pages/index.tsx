import type {NextPage} from 'next'
import Head from 'next/head'
import Image from 'next/image'
import React from "react";
import { Seo } from '../components/Seo';

const Home: NextPage = () => {
    return (
        <>
            <Seo title="Главная" />
            Home
        </>
    )
}

export default Home
