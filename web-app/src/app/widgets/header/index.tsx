import { LoginLink } from "@/app/features/login-link/ui";
import { SearchBlock } from "@/app/features/search-block";
import { LogoLink } from "@/app/widgets/header/ui/logo-link";
import React from 'react';
import styles from './Header.module.scss';

export function Header() {
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