import { Identity } from "@/domain/identity";
import { Nullable } from "@/shared/model/types";
import { createStore } from "effector";
import { isNil } from "lodash";

export const $identity = createStore<Nullable<Identity>>(null);
export const $loggedIn = $identity.map(identity => !isNil(identity))