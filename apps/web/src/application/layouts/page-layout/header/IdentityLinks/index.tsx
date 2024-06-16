"use client";

import React from 'react';
import { useUnit } from 'effector-react';
import { Button } from '@radix-ui/themes';
import { loginFx } from '@/features/auth/by-email';
import { $loggedIn } from '@/_old/model/store';

type Props = {
    
};

const IdentityLinks: React.FC<Props> = ({}) => {
    const loggedIn = useUnit($loggedIn);
    const login = useUnit(loginFx);

    function handleLogin() {
        login({
            email: '123@123.123',
            password: '123123'
        });
    }


    if(loggedIn) {
        return (
            <Button size="3">Выход</Button>
        )
    }

    return (
        <>
            <Button size="3" onClick={handleLogin}>Вход</Button>
            <Button size="3">Регистрация</Button>
        </>
    )
}

export { IdentityLinks }