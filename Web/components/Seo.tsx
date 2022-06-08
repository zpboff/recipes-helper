import React from 'react';
import Head from "next/head";

type Props = {
    title: string;
    description?: string;
    keywords?: string[];
};

const Seo: React.FC<Props> = ({ keywords, title, description }) => {
    return (
        <Head>
            <title>{title} | Recipes Helper</title>
            <meta name="description" content={`${description ?? title} | Recipes Helper`} />
            {!!keywords && (
                <meta name="keywords" content={keywords.join(',')}/>
            )}
        </Head>
    );
};

export {Seo}