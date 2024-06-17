import { Maybe } from "@/core/utils/maybe";
import { LoginParams } from "@/domain/models/session/ISessionService";
import { Session } from "@/domain/models/session/model";
import { ISessionRepository } from "@/domain/repositories/ISessionRepository";

async function login(params: LoginParams) {
    return Maybe.from<Session>({
        name: "zpb-off",
        avatar: "https://ui-avatars.com/api/?name=zpb+off"
    });
}

async function registration(params: LoginParams) {
    return Maybe.from<Session>({
        name: "zpb-off",
        avatar: "https://ui-avatars.com/api/?name=zpb+off"
    });
}

async function logout() {
    return Maybe.from(true);
}

export const sessionRepository: ISessionRepository = {
    login,
    logout,
    registration
}