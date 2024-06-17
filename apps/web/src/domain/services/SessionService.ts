import { ISessionService, LoginParams, RegistrationParams } from "../models/session/ISessionService";
import { ISessionRepository } from "../repositories/ISessionRepository";

async function login(sessionRepository: ISessionRepository, params: LoginParams) {
    return sessionRepository.login(params);
}

async function registration(sessionRepository: ISessionRepository, params: RegistrationParams) {
    return sessionRepository.registration(params);
}

async function logout(sessionRepository: ISessionRepository) {
    return sessionRepository.logout();
}

export const sessionService: ISessionService = {
    login,
    registration,
    logout
}