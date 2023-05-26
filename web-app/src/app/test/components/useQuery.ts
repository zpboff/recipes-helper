import React, { useEffect, useState } from "react";
import { Subject } from "rxjs";

export const query$ = new Subject<string>();

export function useQuery() {
    const [query, setQuery] = useState("");
    
    function onQueryChange(event: React.ChangeEvent<HTMLInputElement>) {
        query$.next(event.target.value);
    }

    useEffect(() => {
        query$.subscribe((newValue) => setQuery(newValue));
        
        return () => query$.unsubscribe();
    }, []);
    
    return [query, onQueryChange];
}