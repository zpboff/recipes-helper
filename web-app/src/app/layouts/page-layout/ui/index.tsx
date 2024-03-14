import React, { PropsWithChildren } from "react";
import { SideMenu } from "@/app/widgets/side-menu/ui";
import styles from "./styles.module.scss";

export function PageLayout({ children }: PropsWithChildren) {
    return (
        <div className={styles.container}>
            <div className={styles.grid}>
                <SideMenu />
                <main className={styles.content}>{children}</main>    
            </div>            
        </div>
    );
}