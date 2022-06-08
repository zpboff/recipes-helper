import React, { PropsWithChildren } from 'react';
import styles from './Content.module.css'

type Props = {
    className?: string;
};

const Content: React.FC<PropsWithChildren<Props>> = ({ children, className = "" }) => {
    return (
        <div className={`${styles.content} ${className}`}>
            {children}
        </div>
    );
};

export {Content}