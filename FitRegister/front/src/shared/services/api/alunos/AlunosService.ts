import { Envioriment } from "../../../environment";
import { Api } from "../axios-config";

export interface  IListagemAlunos {
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

export interface IDetalheAluno {
    id: string; 
    nome?: string;
    endereco?: string;
    telefone?: string;
    email?: string;
    planoId?: string;
    professorId?: string;
    treinoId?: string;
    criadoEm?: string; 
}

type TAlunosComTotalCount ={
    data: IListagemAlunos[];
    totalCount: number;
}


//todos os metodos de crud
const getAll = async(page= 1 , filter = ''): Promise<TAlunosComTotalCount | Error> => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/aluno/listar?_page=${page}&_limits=${Envioriment.LIMITE_DE_LINHAS}&nome_like=${filter}`;

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
            
const getById = async(id: string): Promise<IDetalheAluno | Error > => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/aluno/buscar/${id}`;

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

const create = async(dados: Omit<IDetalheAluno, 'id'>): Promise<string | Error > => {
    try {


        const {data} = await Api.post<IDetalheAluno>(`/api/aluno/cadastrar`, dados); 

        if (data){
            return data.id;
        }
        
        return new Error( 'Erro ao consultar o registro');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao criar o registro');
    }
};

const updateById = async( dados: IDetalheAluno): Promise<void | Error > => {
    try {
        await Api.put<IDetalheAluno>(`/api/aluno/alterar/`,dados); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao atualizar o registro');
    }
};

const deleteById = async(id: string): Promise<void | Error> => {
    try {
        await Api.delete<IDetalheAluno>(`/api/aluno/deletar/${id}`); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao deletar o registro');
    } 
};


export const AlunosService = {
    getAll,
    getById,
    create,
    updateById,
    deleteById,
}