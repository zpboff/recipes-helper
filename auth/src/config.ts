import { isNil } from "lodash";

export type Config = {
    SecretKey: string;
    Salt: number;
}

export const config: Config = {
    SecretKey: process.env.SECRET_KEY ?? "",
    Salt: isNil(process.env.SALT) ? 10 : parseInt(process.env.SALT)
}