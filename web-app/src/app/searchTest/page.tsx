"use client";

import { client } from "@/app/core/apiClient";
import { ChangeEvent, FormEvent, useState } from "react";

export const metadata = {
    title: 'Поиск - Подбор рецептов',
    description: 'Поиск',
}

export default function Login() {    
    const [query, setQuery] = useState("");
    const [response, setResponse] = useState("");
    
    const handleChangeQuery = (event: ChangeEvent<HTMLInputElement>) => {
        setQuery(event.target.value);
    } 
    
    const search = async (event: FormEvent) => {
        event.preventDefault();
        
        const result = await client.get(`/searchRecipe/${query}`);
        setResponse(JSON.stringify(result));
    }
    
    return (
        <div>
            <h1>Поиск</h1>
            <form onSubmit={search}>
                <h2>Поисковый запрос</h2>
                <input value={query} onChange={handleChangeQuery} />
            </form>
            <section>
                {response}
            </section>
        </div>
    );
}