export enum NotificationStatus {
    Info,
    Success,
    Warning,
    Fail
}

export type NotificationItem = {
    id: string;
    status: NotificationStatus;
    content: React.ReactNode;
}