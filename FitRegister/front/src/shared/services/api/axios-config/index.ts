import axios from "axios";
import { errorInterceptor, responseInterceptor } from "./interceptors";
import { Envioriment } from "../../../environment";

const Api = axios.create({
    baseURL: Envioriment.URL_BASE
});

Api.interceptors.response.use(
    (response)=> responseInterceptor(response),
    (error)=> errorInterceptor(error),
);

export {Api}