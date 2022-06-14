import type {NextPage} from 'next';
import React, { useContext, useEffect } from "react";
import { NotificationsContext } from '../components/Notifications';
import { NotificationStatus } from '../components/Notifications/types';
import { Seo } from '../components/Seo';
import { Case, Switch } from '../components/Switch';
import { useOnMount } from '../hooks/useOnMount';

const Home: NextPage = () => {
    const { pushNotification } = useContext(NotificationsContext)

    useOnMount(() => {
        console.count("notification")
        pushNotification({
            content: "123",
            status: NotificationStatus.Success
        });
    })

    return (
        <>
            <Seo title="Главная" />
            Home
        </>
    )
}

export default Home
