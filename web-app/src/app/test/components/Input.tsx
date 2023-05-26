'use client';

import { useQuery } from "@/app/test/components/useQuery";
import React  from 'react';

type Props = {
    
};

export function Input({}: Props) {
    const [query, onChange] = useQuery();
    
    return (
        <input value={query} onChange={onChange}/>
    );
}