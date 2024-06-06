import Link from "next/link";
import { IconUser } from '@tabler/icons-react';
import styles from './styles.module.scss';

export function LoginLink() {
    return (
        <Link href="/login" className={styles.loginLink}>
            <IconUser />
            Войти
        </Link>
    );
}