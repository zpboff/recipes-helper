import React, { useContext, useEffect } from 'react';
import clsx from 'clsx';
import { NotificationItem, NotificationStatus } from './types';
import styles from './Notification.module.css';
import { NotificationsContext } from '.';
import { XIcon } from '../Icons/XIcon';
import { Case, Switch } from '../Switch';
import { CircleXIcon } from '../Icons/CircleXIcon';
import { CircleAlertIcon } from '../Icons/CircleAlertIcon';
import { CircleInfoIcon } from '../Icons/CircleInfoIcon';
import { CircleSuccessIcon } from '../Icons/CircleSuccessIcon';

type Props = {
    notification: NotificationItem;
};

const notificationLifeTimeMs = 3 * 1000;

const NotificationTile: React.FC<Props> = ({ notification }) => {
    const { removeNotification } = useContext(NotificationsContext);

    const handleRemove = () => removeNotification(notification.id);

    useEffect(() => {
        const timeout = setTimeout(handleRemove, notificationLifeTimeMs);

        return () => {
            clearTimeout(timeout);
        }
    }, []);

    return (
        <div className={styles.notification}>
            <div className={clsx(styles.status, {
                [styles.info]: notification.status === NotificationStatus.Info,
                [styles.success]: notification.status === NotificationStatus.Success,
                [styles.warning]: notification.status === NotificationStatus.Warning,
                [styles.fail]: notification.status === NotificationStatus.Fail,
            })}>
                <Switch on={notification.status}>
                    <Case when={NotificationStatus.Info} then={() => <CircleInfoIcon />} />
                    <Case when={NotificationStatus.Success} then={() => <CircleSuccessIcon />} />
                    <Case when={NotificationStatus.Warning} then={() => <CircleXIcon />} />
                    <Case when={NotificationStatus.Fail} then={() => <CircleAlertIcon width={24} height={24} />} />
                </Switch>
            </div>
            <div className={styles.content}>
                {notification.content}
            </div>
            <div className={styles.close} onClick={handleRemove}>
                <XIcon />
            </div>
        </div>
    )
}

export { NotificationTile }