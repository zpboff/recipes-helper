import { Identity } from "@/entities/identity";
import { LoginRequest } from "@/features/auth/by-email/api/types";

export const login = async ({ email, password }: LoginRequest): Promise<Identity> => {
    console.log(email, password);

    const result: Identity = {
        avatar: null,
        name: "zpb-off"
    }

    return result;
}