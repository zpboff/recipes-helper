import { LoginRequest } from "@/app/login/types";
import { combine, createEffect, createEvent, createStore, forward, sample } from "effector";

const $email = createStore("");
const emailChanged = createEvent<string>();
forward({ from: emailChanged, to: $email });

const $password = createStore("");
const passwordChanged = createEvent<string>();
forward({ from: passwordChanged, to: $password });

const $loginRequest = combine($email, $password, (email, password): LoginRequest => ({ email, password }));
const submitted = createEvent();

const loginFx = createEffect<LoginRequest, void>({
    name: "Login",
    handler: async ({ email, password }) => {
        console.log(email, password);
    }
});

sample({
    source: $loginRequest,
    clock: submitted,
    name: "Login",
    target: loginFx
});

export {
    $email,
    $password,
    emailChanged,
    passwordChanged,
    submitted
}