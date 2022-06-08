import { PropsWithChildren } from 'react';
import Head from "next/head";
import Image from "next/image";
import Link from "next/link";
import styles from "./Layout.module.css";
import { Container } from '../Container';
import { Content } from '../Content';

export const Layout: React.FC<PropsWithChildren> = ({ children }) => {
    return (
        <div className={styles.app}>
            <Head>
                <link rel="icon" href="/favicon.png"/>
            </Head>
            <header className={styles.header}>
                <Link href="/">
                    <a>
                        <Image src="/logo.png" title="Recipes helper" alt="Recipes helper" width={32} height={32} />
                    </a>    
                </Link>
            </header>
            <aside className={styles.aside}>
                
            </aside>
            <main className={styles.main}>
                <Container>
                    <Content>
                        {children}
                    </Content>
                </Container>
            </main>
        </div>
    )
}