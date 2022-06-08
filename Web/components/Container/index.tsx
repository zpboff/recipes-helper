import React, { PropsWithChildren } from 'react';
import styles from './Container.module.css'

type Props = {
    
};

const Container: React.FC<PropsWithChildren<Props>> = ({ children }) => {
    return (
        <div className={styles.container}>
            {children}
        </div>
    );
};

export {Container}