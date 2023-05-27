import { SideMenu } from "./SideMenu";
import styles from "./PageContent.module.scss";
import { PropsWithChildren } from "react";

export function PageContent({ children }: PropsWithChildren) {
    return (
        <div className={styles.container}>
            <div className={styles.grid}>
                <SideMenu />
                <main className={styles.content}>{children}</main>    
            </div>            
        </div>
    );
}