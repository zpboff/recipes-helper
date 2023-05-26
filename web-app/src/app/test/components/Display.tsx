'use client';
import { useQuery } from "@/app/test/components/useQuery";
import React from 'react';

type Props = {
    
};

export function Display({}: Props) {
    const [query] = useQuery();
    
    return (
        <div>{query}</div>
    );
}