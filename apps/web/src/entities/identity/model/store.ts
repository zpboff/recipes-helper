import { Nullable } from "@/shared/model/types";
import { createStore, sample } from "effector";
import { Identity } from "./types";
import { identity, isNil } from "lodash";

export const $identity = createStore<Nullable<Identity>>(null);
export const $loggedIn = $identity.map(identity => !isNil(identity))