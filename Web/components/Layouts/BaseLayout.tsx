import { PropsWithChildren } from 'react';
import Head from "next/head";
import Image from "next/image";
import Link from "next/link";
import styles from "./Layout.module.css";
import { Container } from '../Container';
import { Content } from '../Content';

export const BaseLayout: React.FC<PropsWithChildren> = ({ children }) => {
    return (
        <div className={styles.app}>
            <Head>
                <link rel="icon" href="/favicon.png"/>
                <link rel="preconnect" href="https://fonts.googleapis.com" />
                <link rel="preconnect" href="https://fonts.gstatic.com" crossOrigin="true" />
                <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400&display=swap" rel="stylesheet" />
            </Head>
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
                    <Link href="/login">
                        <a className={styles.navLink}>
                            Вход
                        </a>
                    </Link>
                    <Link href="/register">
                        <a className={styles.navLink}>
                            Регистрация
                        </a>
                    </Link>
                </div>
            </header>
            <main className={styles.main}>
                {children}
            </main>
        </div>
    )
}