import { PropsWithChildren } from 'react';
import Head from "next/head";
import Image from "next/image";
import Link from "next/link";
import styles from "./Layout.module.css";
import { Container } from '../Container';
import { Content } from '../Content';
import { BaseLayout } from './BaseLayout';

export const MainLayout: React.FC<PropsWithChildren> = ({ children }) => {
    return (
        <BaseLayout>  
            <div className={styles.content}>    
                <aside className={styles.aside}>
                    Меню
                </aside>
                <Container>
                    <section className={styles.pageContent}>
                        {children}
                    </section>
                </Container>
            </div>
        </BaseLayout>
    )
}