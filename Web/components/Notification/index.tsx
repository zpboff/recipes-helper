import React, { createContext, PropsWithChildren, useReducer } from 'react';
import { Dictionary } from '../../types/shared';
import { NotificationsList } from './NotificationsList';
import { NotificationCreateModel, notificationsReducer, pushNotification, removeNotification } from './notificationsReducer';
import { NotificationItem } from './types';


export type NotificationsContextType = {
    items: Dictionary<NotificationItem>;
    pushNotification: (notification: NotificationCreateModel) => void;
    removeNotification: (id: string) => void;
}

const NotificationsContext = createContext<NotificationsContextType>({
    items: {},
    pushNotification: () => {},
    removeNotification: () => {}
});

type Props = PropsWithChildren<{
    
}>;

const NotificationsProvider: React.FC<Props> = ({ children }) => {
    const [notifications, dispatch] = useReducer(notificationsReducer, {});

    const push = (notification: NotificationCreateModel) => dispatch(pushNotification(notification));
    const remove = (id: string) => dispatch(removeNotification(id));

    return (
        <NotificationsContext.Provider value={{
            items: notifications,
            pushNotification: push,
            removeNotification: remove
        }}>
            {children}
            <NotificationsList items={Object.values(notifications)} />
        </NotificationsContext.Provider>
    )
}

export { NotificationsProvider, NotificationsContext }