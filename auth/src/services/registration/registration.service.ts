import { RegistrationRequest, RegistrationResponse } from "./registration.types";
import { compare, hash } from 'bcrypt';
import { isNil } from "lodash";
import { config } from "../../config";
import { User, createUser, getUser } from "../user";
import { generateTokens } from "../token";

export async function registration(request: RegistrationRequest): Promise<RegistrationResponse | null> {
    const possibleUser = getUser(request.email);

    if(!isNil(possibleUser)) {
        return null;
    }

    const passwordHash = await hash(request.password, config.Salt);

    const user: User = {
        email: request.email,
        passwordHash
    }

    await createUser(user);

    return generateTokens(user);
}