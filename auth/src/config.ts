import { config } from "dotenv";
import { isNil } from "lodash";

export type Settings = {
    SecretKey: string;
    Salt: number;
}

config();

export const settings: Settings = {
    SecretKey: process.env.SECRET_KEY ?? "",
    Salt: isNil(process.env.SALT) ? 10 : parseInt(process.env.SALT)
}