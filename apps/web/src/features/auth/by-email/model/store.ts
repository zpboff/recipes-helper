import { $identity } from "@/entities/identity";
import { login, LoginRequest } from "../api";
import { combine, createEffect, createEvent, createStore, forward, sample } from "effector";

const $email = createStore("");
const emailChanged = createEvent<string>();
sample({ clock: emailChanged, target: $email });

const $password = createStore("");
const passwordChanged = createEvent<string>();
sample({ clock: passwordChanged, target: $password });
 
const $loginRequest = combine($email, $password, (email, password): LoginRequest => ({ email, password }));
const submitted = createEvent();

const loginFx = createEffect({
    name: "Login",
    handler: login
});

sample({
    source: $loginRequest,
    clock: submitted,
    name: "Login",
    target: loginFx
});

sample({ clock: loginFx.doneData, target: $identity })

export {
    $email,
    $password,
    emailChanged,
    passwordChanged,
    submitted,
    loginFx
}