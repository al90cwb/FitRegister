import { Envioriment } from "../../../environment";
import { Api } from "../axios-config";

export interface  IListagemProfessores {
    id?: string; 
    nome?: string;
    endereco?: string;
    telefone?: string;
    email?: string;
    planoId?: string;
    professorId?: string;
    treinoId?: string;
    criadoEm?: string; 
}

export interface IDetalheProfessores {
    id: string; 
    nome: string;
    endereco: string;
    telefone: string;
    email: string;
    planoId: string;
    professorId?: string;
    treinoId?: string;
    criadoEm?: string; 
}

type TProfessorsComTotalCount ={
    data: IListagemProfessores[];
    totalCount: number;
}


//todos os metodos de crud
const getAll = async(page= 1 , filter = ''): Promise<TProfessorsComTotalCount | Error> => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/professor/listar?_page=${page}&_limits=${Envioriment.LIMITE_DE_LINHAS}&nome_like=${filter}`;

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
       

const getById = async(id: string): Promise<IDetalheProfessores | Error > => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/professor/buscar/${id}`;

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

const create = async(dados: Omit<IDetalheProfessores, 'id'>): Promise<string | Error > => {
    try {


        const {data} = await Api.post<IDetalheProfessores>(`/api/professor/cadastrar`, dados); 

        if (data){
            return data.id;
        }
        
        return new Error( 'Erro ao consultar o registro');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao criar o registro');
    }
};

const updateById = async( dados: Omit<IDetalheProfessores, 'criadoEm'>): Promise<void | Error > => {
    try {
        await Api.put<IDetalheProfessores>(`/api/professor/alterar/`,dados); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao atualizar o registro');
    }
};

const deleteById = async(id: string): Promise<void | Error> => {
    try {
        await Api.delete<IDetalheProfessores>(`/api/professor/deletar/${id}`); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao deletar o registro');
    } 
};


export const ProfessoresService = {
    getAll,
    getById,
    create,
    updateById,
    deleteById,
}