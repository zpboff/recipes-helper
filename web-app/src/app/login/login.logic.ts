import { LoginRequest } from "@/app/login/types";
import { combine, createEffect, createEvent, createStore, forward, sample } from "effector";

const $email = createStore("");
const $password = createStore("");

const emailChanged = createEvent<string>();
const passwordChanged = createEvent<string>();

forward({ from: emailChanged, to: $email });
forward({ from: passwordChanged, to: $password });

const $loginRequest = combine($email, $password, (email, password) => ({ email, password } as LoginRequest));
const submitted = createEvent();

const loginFx = createEffect<LoginRequest, boolean>({
    name: "Login",
    handler: async ({ email, password}) => {
        console.log(email, password);
        return email === password;
    }
});

sample({
    name: "Login",
    clock: submitted,
    source: $loginRequest,
    target: loginFx
});

export {
    $email,
    $password,
    emailChanged,
    passwordChanged,
    submitted
}