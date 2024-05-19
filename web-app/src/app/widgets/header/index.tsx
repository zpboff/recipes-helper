import { LoginLink } from "@/app/features/login-link/ui";
import { SearchBlock } from "@/app/features/search-block";
import { LogoLink } from "@/app/widgets/header/ui/logo-link";
import React from 'react';
import styles from './styles.module.scss';

export function Header() {
    return (
        <header className={styles.header}>
            <LogoLink />            
            <SearchBlock />
            <LoginLink />
        </header>
    );
}