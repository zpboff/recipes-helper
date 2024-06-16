import { Theme } from '@radix-ui/themes';
import React, { PropsWithChildren } from 'react';
import styles from "./base-layout.module.css";
import '@radix-ui/themes/styles.css';

const BaseLayout: React.FC<PropsWithChildren<unknown>> = ({ children }) => {
    return (        
        <Theme className={styles.root} accentColor="red">
            {children}
        </Theme>
    )
}

export { BaseLayout }