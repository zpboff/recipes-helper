import { Maybe } from "@/core/utils/maybe";
import { Session } from "./model";
import { ISessionRepository } from "@/domain/repositories/ISessionRepository";

export type LoginParams = {
    email: string;
    password: string;
}

export type RegistrationParams = {
    email: string;
    password: string;
    passwordConfirmation: string;
}

export interface ISessionService {
    login: (sessionRepository: ISessionRepository, params: LoginParams) => Promise<Maybe<Session>>;
    registration: (sessionRepository: ISessionRepository,params: RegistrationParams) => Promise<Maybe<Session>>;
    logout: (sessionRepository: ISessionRepository) => Promise<Maybe<boolean>>;
}