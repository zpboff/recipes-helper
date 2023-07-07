import { Tokens } from "../token";

export type LoginRequest = {
    email: string;
    password: string;
}

export type LoginResponse = Tokens;