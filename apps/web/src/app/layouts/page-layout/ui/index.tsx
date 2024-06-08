import { Header } from "@/app/widgets/header";
import React, { PropsWithChildren } from "react";
import { Theme } from "@radix-ui/themes";
import styles from "./styles.module.scss";
import '@radix-ui/themes/styles.css';

export function PageLayout({ children }: PropsWithChildren) {
    return (
        <Theme className={styles.root}>
            <Header />
            <main className={styles.content}>
                {children}
            </main>
        </Theme>
    );
}
