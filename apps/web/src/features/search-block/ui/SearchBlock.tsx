"use client";

import React, { FormEvent, useState } from 'react';
import {Input} from "@/shared/ui/input";

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