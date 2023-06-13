"use client";

import { useStore } from 'effector-react';
import React, { ChangeEvent, FormEvent } from 'react';
import { $query, queryChanged, searchSubmitted } from './SearchBlock.logic';

type Props = {
    
};

const SearchBlock: React.FC<Props> = ({}) => {
    const query = useStore($query);

    const onQueryChange = (event: ChangeEvent<HTMLInputElement>) => {
        queryChanged(event.target.value);
    }

    const handleSearch = (event: FormEvent) => {
        event.preventDefault();
        searchSubmitted();
    }

    return (
        <form onSubmit={handleSearch}>
            <input value={query} onChange={onQueryChange}/>
        </form>
    )
}

export { SearchBlock }