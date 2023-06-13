"use client";

import { $email, $password, emailChanged, passwordChanged, submitted } from "@/app/login/login.logic";
import { useStore } from "effector-react";
import React, { ChangeEvent, FormEvent } from 'react';
import styles from './LoginForm.module.scss';

type Props = {
    
};

export function LoginForm({}: Props) {
    const email = useStore($email);
    const password = useStore($password);
    
    const changeEmail = (event: ChangeEvent<HTMLInputElement>) => emailChanged(event.target.value);
    const changePassword = (event: ChangeEvent<HTMLInputElement>) => passwordChanged(event.target.value);
    
    const handleLogin = async (e: FormEvent) => {
        e.preventDefault();
        submitted();
    }
    
    return (
        <form onSubmit={handleLogin} className={styles.form}>
            <input value={email} onChange={changeEmail} />
            <input value={password} onChange={changePassword} />
            <button>Войти</button>
        </form>
    );
}