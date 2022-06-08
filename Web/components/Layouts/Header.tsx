import React from 'react';
import Image from "next/image";
import Link from "next/link";
import styles from './Header.module.css';

type Props = {
    
};

const Header: React.FC<Props> = ({}) => {
    return (
        <header className={styles.header}>
            <Link href="/">
                <a className={styles.navLink}>
                    <Image 
                        src="/logo.png"
                        title="Recipes helper" 
                        alt="Recipes helper" 
                        width={32}
                        height={32}
                    />
                </a>    
            </Link>
            <div className={styles.linkBlock}>
                <Link href="/login" className={styles.navLink}>
                    <a>
                        Вход
                    </a>
                </Link>
                <Link href="/register" className={styles.navLink}>
                    <a>
                        Регистрация
                    </a>
                </Link>
            </div>
        </header>
    )
}

export { Header }