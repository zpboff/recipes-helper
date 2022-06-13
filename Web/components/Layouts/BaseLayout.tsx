import { PropsWithChildren } from 'react';
import Head from "next/head";
import styles from "./Layout.module.css";
import { Header } from './Header';
import { NotificationsProvider } from '../Notification';

const BaseLayout: React.FC<PropsWithChildren> = ({ children }) => {
    return (
        <NotificationsProvider>
            <div className={styles.app}>
                <Head>
                    <link rel="icon" href="/favicon.png"/>
                    <link rel="preconnect" href="https://fonts.googleapis.com" />
                    <link rel="preconnect" href="https://fonts.gstatic.com" crossOrigin="true" />
                    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400&display=swap" rel="stylesheet" />
                </Head>
                <Header />
                <main className={styles.main}>
                    {children}
                </main>
            </div>
            <div id="notifications" />
        </NotificationsProvider>
    )
}

export { BaseLayout }