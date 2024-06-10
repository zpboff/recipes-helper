import { Header } from "@/widgets/header";
import React, { PropsWithChildren } from "react";
import { Box, Theme } from "@radix-ui/themes";
import styles from "./styles.module.scss";
import '@radix-ui/themes/styles.css';

export function PageLayout({ children }: PropsWithChildren) {
    return (
        <Theme className={styles.root} accentColor="red">
            <Header />
                <main className={styles.content}>
                    {children}
                </main>        
        </Theme>
    );
}
