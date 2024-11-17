import  { AxiosError } from 'axios';

export const errorInterceptor = (error: AxiosError) => {

    //interceptar a mensagem de erro
    if (error.message === 'Network Error'){
        return Promise.reject(new Error('Erro de conexão'))
    }
    if (error.response?.status === 401){
        //
    }

    return Promise.reject(error);
}