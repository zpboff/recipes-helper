"use client";

import { Input } from "@/app/shared/ui/input";
import React, { FormEvent, useState } from 'react';

const SearchBlock: React.FC = () => {
    const [query, setQuery] = useState("");
    
    function handleSearch(event: FormEvent) {
        event.preventDefault();
    }
    
    return (
        <form onSubmit={handleSearch}>
            <Input value={query} onValueChange={setQuery} />
        </form>
    )
}

export { SearchBlock }