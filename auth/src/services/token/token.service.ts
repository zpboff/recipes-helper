import { sign } from 'jsonwebtoken';
import { v4 } from 'uuid';
import { config } from "../../config";
import { User } from "../user";
import { Tokens } from ".";

export const generateTokens = async (user: User): Promise<Tokens | null> => {
    const accessToken = sign(user, config.SecretKey);
    const refreshToken = v4();

    return {
        accessToken,
        refreshToken
    }
}