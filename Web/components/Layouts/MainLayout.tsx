import { PropsWithChildren } from 'react';
import styles from "./Layout.module.css";
import { BaseLayout } from './BaseLayout';

export const MainLayout: React.FC<PropsWithChildren> = ({ children }) => {
    return (
        <BaseLayout>  
            <div className={styles.content}>    
                <aside className={styles.aside}>
                    Меню
                </aside>
                <section className={styles.pageContent}>
                    {children}
                </section>
            </div>
        </BaseLayout>
    )
}