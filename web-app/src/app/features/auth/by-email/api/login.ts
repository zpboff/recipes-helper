import { LoginRequest } from "@/app/features/auth/by-email/api/types";

export const login = async ({ email, password }: LoginRequest) => {
    console.log(email, password);
}