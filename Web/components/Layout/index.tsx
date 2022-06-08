import { PropsWithChildren } from 'react';
import Head from "next/head";
import styles from "./Layout.module.css";
import { Container } from '../Container';
import { Content } from '../Content';

export type LayoutProps = {
}

export const Layout: React.FC<PropsWithChildren<LayoutProps>> = ({ children }) => {
    return (
        <div className={styles.app}>
            <Head>
                <link rel="icon" href="/favicon.png"/>
            </Head>
            <header className={styles.header}>
            </header>
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