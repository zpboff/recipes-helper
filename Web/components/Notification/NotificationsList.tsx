import React from 'react';
import { createPortal } from 'react-dom';
import { NotificationItem } from '.';
import { NotificationTile } from './NotificationTile';
import styles from './Notification.module.css';

type Props = {
    items: NotificationItem[];
};

const NotificationsList: React.FC<Props> = ({ items }) => {
    return (
        <section className={styles.container}>
            {items.map(notification => (
                <NotificationTile notification={notification} key={notification.id} />
            ))}
        </section>
    )
}

export { NotificationsList }