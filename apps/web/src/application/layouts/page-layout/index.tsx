import React, { PropsWithChildren } from "react";
import styles from "./page-layout.module.scss";
import { BaseLayout } from "@/application/layouts/baseLayout";
import { Header } from "./header";

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
