import { Nullable } from "@/app/shared/model/types";
import { createStore, sample } from "effector";
import { Identity } from "./types";
import { isNil } from "lodash";

export const $identity = createStore<Nullable<Identity>>(null);
export const $loggedIn = sample({
    source: $identity,
    fn: identity => !isNil(identity)
})