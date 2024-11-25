import { Envioriment } from "../../../environment";
import { Api } from "../axios-config";

export interface  IListagemPlanos {
    id?: string; 
    nomePlano?: string;
    valor?: number;
    parcelas?: number;
    criadoEm?: string; 
}

export interface IDetalhePlano {
    id: string; 
    nomePlano: string;
    valor: number;
    parcelas: number;
}

type TPlanosComTotalCount ={
    data: IListagemPlanos[];
    totalCount: number;
}


//todos os metodos de crud
const getAll = async(page= 1 , filter = ''): Promise<TPlanosComTotalCount | Error> => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/plano/listar?_page=${page}&_limits=${Envioriment.LIMITE_DE_LINHAS}&nome_like=${filter}`;

        const {data, headers} = await Api.get(urlRelativa); //limitando total de consultas por pagina 

        if (data){
            
            console.log(headers['x-total-count']);
            return{
                data,
                totalCount: Number(headers['x-total-count']  || Envioriment.LIMITE_DE_LINHAS )
                
            };
        }
        return new Error( 'Erro ao listar os registros');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao listar os registros');
    }
};
       

const getById = async(id: string): Promise<IDetalhePlano | Error > => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/plano/buscar/${id}`;

        const {data} = await Api.get(urlRelativa); //limitando total de consultas por pagina 

        if (data){
            return data;
        };
        
        return new Error( 'Erro ao consultar o registro');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao consultar o registro');
    }
};

const create = async(dados: Omit<IDetalhePlano, 'id'>): Promise<string | Error > => {
    try {


        const {data} = await Api.post<IDetalhePlano>(`/api/plano/cadastrar`, dados); 

        if (data){
            return data.id;
        }
        
        return new Error( 'Erro ao consultar o registro');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao criar o registro');
    }
};

const updateById = async( dados: Omit<IDetalhePlano, 'criadoEm'>): Promise<void | Error > => {
    try {
        await Api.put<IDetalhePlano>(`/api/plano/alterar/`,dados); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao atualizar o registro');
    }
};

const deleteById = async(id: string): Promise<void | Error> => {
    try {
        await Api.delete<IDetalhePlano>(`/api/plano/deletar/${id}`); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao deletar o registro');
    } 
};


export const PlanosService = {
    getAll,
    getById,
    create,
    updateById,
    deleteById,
}