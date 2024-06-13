import { Header } from "@/widgets/header";
import React, { PropsWithChildren } from "react";
import styles from "./page-layout.module.scss";
import { BaseLayout } from "@/layouts/baseLayout";

export function PageLayout({ children }: PropsWithChildren) {
    return (
        <BaseLayout>        
            <Header />
            <main className={styles.content}>
                {children}
            </main>  
        </BaseLayout>    
    );
}
