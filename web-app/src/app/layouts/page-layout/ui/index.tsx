import { Header } from "@/app/widgets/header";
import React, { PropsWithChildren } from "react";
import styles from "./styles.module.scss";

export function PageLayout({ children }: PropsWithChildren) {
    return (
        <>
            <Header />
            <div className={styles.container}>
                <div className={styles.grid}>
                    <main className={styles.content}>
                        {children}
                    </main>
                </div>
            </div>
        </>        
    );
}