import { LoginRequest, LoginResponse } from "./login.types";
import { compare } from 'bcrypt';
import { isNil } from "lodash";
import { getUser } from "../user";
import { generateTokens } from "../token";

export const login = async (request: LoginRequest): Promise<LoginResponse | null> => {
    const user = await getUser(request.email);

    if(isNil(user)) {
        return null;
    }

    const passwordMatched = await compare(request.password, user.passwordHash)

    if(!passwordMatched) {
        return null;
    }

    return generateTokens(user);
}