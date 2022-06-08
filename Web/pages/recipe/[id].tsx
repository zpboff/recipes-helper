import React from 'react';
import {useRouter} from 'next/router';
import {NextPage} from "next";
import Head from "next/head";
import { Seo } from '../../components/Seo';

type Props = {
    id: string;
};

const Recipe: NextPage<Props> = ({ id }) => {
    return (
        <>
            <Seo title={`Рецепт - ${id}`} description={`Рецепт - ${id}`} />
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
