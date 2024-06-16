import { urlsConfig } from "@/shared/config/urlsConfig";
import axios from 'axios';

export const client = axios.create({
    baseURL: urlsConfig.apiUrl
});