import React, { useContext, useEffect } from 'react';
import clsx from 'clsx';
import { NotificationItem, NotificationStatus } from './types';
import styles from './Notification.module.css';
import { NotificationsContext } from '.';

type Props = {
    notification: NotificationItem;
};

const notificationLifeTimeMs = 3 * 1000;

const NotificationTile: React.FC<Props> = ({ notification }) => {
    const { removeNotification } = useContext(NotificationsContext);

    const handleRemove = () => removeNotification(notification.id);

    // useEffect(() => {
    //     const timeout = setTimeout(handleRemove, notificationLifeTimeMs);

    //     return () => {
    //         clearTimeout(timeout);
    //     }
    // }, [])

    return (
        <div className={styles.notification}>
            <div className={clsx(styles.status, {
                [styles.info]: notification.status === NotificationStatus.Info,
                [styles.success]: notification.status === NotificationStatus.Success,
                [styles.warning]: notification.status === NotificationStatus.Warning,
                [styles.fail]: notification.status === NotificationStatus.Fail,
            })}>
                123
            </div>
            <div className={styles.content}>
                {notification.content}
            </div>
            <div className={styles.close} onClick={handleRemove}>3</div>
        </div>
    )
}

export { NotificationTile }