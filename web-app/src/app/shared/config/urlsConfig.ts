import _ from "lodash/isNil";

type UrlsConfig = {
    apiUrl: string;
}

export const urlsConfig: UrlsConfig = {
    apiUrl: handleEnvVar(process.env.NEXT_PUBLIC_BFF_URL)
}

function handleEnvVar(value: string | undefined): string {
    if(_.isNil(value)) {
        throw new Error("Value didn't initialized")
    }
    
    return value!;
}