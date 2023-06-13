import { LoginLink } from "@/app/components/Header/LoginLink";
import { LogoLink } from "@/app/components/Header/LogoLink";
import React from 'react';
import styles from './Header.module.scss';
import { SearchBlock } from "./SearchBlock";

type Props = {
    
};

export function Header({}: Props) {
    return (
        <header className={styles.header}>
            <div className={styles.logoBlock}>
                <LogoLink />    
            </div>            
            <SearchBlock />
            <LoginLink />
        </header>
    );
}