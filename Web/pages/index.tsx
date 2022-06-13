import type {NextPage} from 'next';
import React, { useContext, useEffect } from "react";
import { NotificationsContext } from '../components/Notification';
import { NotificationStatus } from '../components/Notification/types';
import { Seo } from '../components/Seo';
import { useOnMount } from '../hooks/useOnMount';

const Home: NextPage = () => {
    const { pushNotification } = useContext(NotificationsContext)

    useOnMount(() => {
        console.count("notification")
        pushNotification({
            content: "123",
            status: NotificationStatus.Success
        });
    }, [])

    return (
        <>
            <Seo title="Главная" />
            Home
        </>
    )
}

export default Home
