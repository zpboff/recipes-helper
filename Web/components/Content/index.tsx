import React, { PropsWithChildren } from 'react';
import styles from './Content.module.css'

type Props = {
    
};

const Content: React.FC<PropsWithChildren<Props>> = ({ children }) => {
    return (
        <div className={styles.content}>
            {children}
        </div>
    );
};

export {Content}