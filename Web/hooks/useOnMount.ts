import { DependencyList, EffectCallback, useEffect, useRef } from "react"

export const useOnMount = (callback: EffectCallback) => {
    const didMountRef = useRef(false);

    useEffect(() => {
        if(!didMountRef.current) {
            didMountRef.current = true;
            return;
        }

        return callback();
    }, []);
}