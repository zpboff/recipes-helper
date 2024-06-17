import { Maybe } from "@/core/utils/maybe";
import { LoginParams, RegistrationParams } from "../models/session/ISessionService";
import { Session } from "../models/session/model";

export interface ISessionRepository {
    login: (params: LoginParams) => Promise<Maybe<Session>>;
    registration: (params: RegistrationParams) => Promise<Maybe<Session>>;
    logout: () => Promise<Maybe<boolean>>;
}