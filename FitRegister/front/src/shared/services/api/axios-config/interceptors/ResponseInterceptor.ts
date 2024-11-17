
import {AxiosResponse} from 'axios';

export const responseInterceptor = (reponse :  AxiosResponse) => {
    //caso queira fazer algum tatamento na resposta
    
    return reponse;
};