import { Tokens } from "../token/token.types";

export type RegistrationRequest = {
    email: string;
    password: string;
}

export type RegistrationResponse = Tokens