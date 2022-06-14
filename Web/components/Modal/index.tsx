import React, { PropsWithChildren, PropsWithChildren, useState } from 'react';
import { createPortal } from 'react-dom';
import { useOnMount } from '../../hooks/useOnMount';

export type SpecificModalProps = {
    isOpened: boolean;    
    closeModal?: () => void;
}

type Size = "small" | "medium" | "large";

type Props = PropsWithChildren<SpecificModalProps & {
    size?: Size;
}>;

const Modal: React.FC<Props> = ({ isOpened, closeModal, size, children }) => {
    const [isBrowser, setIsBrowser] = useState(false);

    useOnMount(() => setIsBrowser(true));
 
    if(!isBrowser || !isOpened) {
        return null;
    }

    return createPortal(
        <div>
            <div></div>
            <div></div>
            <div>{children}</div>
            <div></div>
        </div>,
        document.getElementById("modal-root") as HTMLElement
    )
}

export { Modal }