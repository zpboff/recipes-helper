"use client";

import React, { ChangeEvent, FormEvent, useState } from 'react';

const SearchBlock: React.FC = () => {
    const [query, setQuery] = useState("");
    
    function handleSearch(event: FormEvent) {
        event.preventDefault();
    }

    function onQueryChange(event: ChangeEvent<HTMLInputElement>) {
        setQuery(event.target.value);
    }
    
    return (
        <form onSubmit={handleSearch}>
            <input value={query} onChange={onQueryChange} />
        </form>
    )
}

export { SearchBlock }