import React from 'react';
import {useRouter} from 'next/router';
import {NextPage} from "next";
import Head from "next/head";

type Props = {
    id: string;
};

const Recipe: NextPage<Props> = ({ id }) => {
    return (
        <>
            <Head>
                <title>Рецепт - {id}</title>
                <meta name="description" content={`Рецепт - ${id}`} />
            </Head>
            Recipe - {id}
        </>
    );
};

Recipe.getInitialProps = async ({ query }) => {
    const {id} = query;
    
    return {
        id: id as string
    };
}

export default Recipe;
