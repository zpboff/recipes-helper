import { User } from "./user.types";

const userStore = new Map<string, User>();

export const createUser = async (user: User) => {
    userStore.set(user.email, user);
};

export const getUser = async (email: string) => userStore.get(email);