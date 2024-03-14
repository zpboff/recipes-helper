"use client";

import React, { ChangeEvent, FormEvent } from 'react';
import { $query, queryChanged, searchSubmitted } from "@/app/features/search-block/model/store";
import { useStore } from 'effector-react';

const SearchBlock: React.FC = () => {
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