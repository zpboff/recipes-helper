import { RegistrationRequest, RegistrationResponse } from "./registration.types";
import { hash, genSalt } from 'bcrypt';
import { isNil } from "lodash";
import { settings } from "../../config";
import { User, createUser, getUser } from "../user";
import { generateTokens } from "../token";

export async function registration(request: RegistrationRequest): Promise<RegistrationResponse | null> {
    const possibleUser = await getUser(request.email);

    if(!isNil(possibleUser)) {
        return null;
    }

    const salt = await genSalt(settings.Salt);
    const passwordHash = await hash(request.email, salt);

    const user: User = {
        email: request.email,
        passwordHash
    }

    await createUser(user);

    return generateTokens(user);
}