import React, { MutableRefObject, useEffect } from 'react';

export function useClickOutside<TElement extends HTMLElement>(ref: MutableRefObject<TElement | null>, callback: (event: MouseEvent | TouchEvent) => void) {
    useEffect(() => {
        const listener = (event: MouseEvent | TouchEvent) => {
            const target = event.target as TElement;
            
            if(!ref.current || ref.current.contains(target)) {
                return;
            }
            
            callback(event);
        }
        
        document.addEventListener('click', listener);
        document.addEventListener('touchstart', listener);
        
        return () => {
            document.removeEventListener('click', listener);
            document.removeEventListener('touchstart', listener);
        }
    }, [ref.current])
}
