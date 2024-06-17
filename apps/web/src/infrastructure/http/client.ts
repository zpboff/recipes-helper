import axios from 'axios';
import { handleEnvVar } from "@/core/utils/handleEnvVar";

type UrlsConfig = {
    apiUrl: string;
}

const urlsConfig: UrlsConfig = {
    apiUrl: handleEnvVar(process.env.NEXT_PUBLIC_BFF_URL)
}

export const client = axios.create({
    baseURL: urlsConfig.apiUrl,
    withCredentials: true
});