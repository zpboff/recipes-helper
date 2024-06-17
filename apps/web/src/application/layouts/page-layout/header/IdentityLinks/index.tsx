"use client";

import React from 'react';
import { Button } from '@radix-ui/themes';

type Props = {
    
};

const IdentityLinks: React.FC<Props> = ({}) => {
    // function handleLogin() {
    //     login({
    //         email: '123@123.123',
    //         password: '123123'
    //     });
    // }


    // if(loggedIn) {
    //     return (
    //         <Button size="3">Выход</Button>
    //     )
    // }

    return (
        <>
            <Button size="3" onClick={console.log}>Вход</Button>
            <Button size="3">Регистрация</Button>
        </>
    )
}

export { IdentityLinks }