import { Dictionary } from "../../types/shared";
import { NotificationItem } from "./types";
import { v4 } from 'uuid';

export type NotificationCreateModel = Omit<NotificationItem, "id">

type PushNotificationAction = {
    type: "notifications/pushNotification"
    notification: NotificationItem;
}

export const pushNotification = (notification: NotificationCreateModel): PushNotificationAction => ({
    notification: {
        ...notification,
        id: v4()
    },
    type: "notifications/pushNotification"
});

type RemoveNotificationAction = {
    type: "notifications/removeNotification"
    id: string;
}

export const removeNotification = (id: string): RemoveNotificationAction => ({
    id,
    type: "notifications/removeNotification"
});

type NotificationAction = PushNotificationAction | RemoveNotificationAction;

export const notificationsReducer = (state: Dictionary<NotificationItem>, action: NotificationAction) => {
    switch(action.type) {
        case "notifications/pushNotification":
            return {
                ...state, 
                [action.notification.id]: action.notification
            };
        case "notifications/removeNotification":
            delete state[action.id];
            
            return {...state};
        default:
            return state;
    }
}