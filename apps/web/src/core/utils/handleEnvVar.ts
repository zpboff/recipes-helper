import { isNil } from "lodash";

export function handleEnvVar(value: string | undefined): string {
    if(isNil(value)) {
        throw new Error("Value didn't initialized")
    }
    
    return value!;
}