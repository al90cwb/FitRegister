import { Envioriment } from "../../../environment";
import { Api } from "../axios-config";

export interface  IListagemExercicios {
    id?: string; 
    nome?: string;
    grupoMuscular?: string;
    descricao?: string;
    repeticoes?: number;
    tempoDescanso?: string;
    criadoEm?: string; 
}

export interface IDetalheExercicio {
    id: string; 
    nome: string;
    grupoMuscular: string;
    descricao: string;
    repeticoes: number;
    tempoDescanso: number;
}

type TExerciciosComTotalCount ={
    data: IListagemExercicios[];
    totalCount: number;
}


//todos os metodos de crud
const getAll = async(page= 1 , filter = ''): Promise<TExerciciosComTotalCount | Error> => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/exercicios/listar?_page=${page}&_limits=${Envioriment.LIMITE_DE_LINHAS}&nome_like=${filter}`;

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
       

const getById = async(id: string): Promise<IDetalheExercicio | Error > => {
    try {

        //verificar esses filtros não temos
        const urlRelativa = `/api/exercicios/buscar/${id}`;

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

const create = async(dados: Omit<IDetalheExercicio, 'id'>): Promise<string | Error > => {
    try {


        const {data} = await Api.post<IDetalheExercicio>(`/api/exercicios/cadastrar`, dados); 

        if (data){
            return data.id;
        }
        
        return new Error( 'Erro ao consultar o registro');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao criar o registro');
    }
};

const createList = async(dados: Omit<IDetalheExercicio, 'id'>): Promise<string | Error > => {
    try {


        const {data} = await Api.post<IDetalheExercicio>(`/api/exercicios/cadastrarlista`, dados); 

        if (data){
            return data.id;
        }
        
        return new Error( 'Erro ao consultar o registro');

    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao criar o registro');
    }
};

const updateById = async( dados: Omit<IDetalheExercicio, 'criadoEm'>): Promise<void | Error > => {
    try {
        await Api.put<IDetalheExercicio>(`/api/exercicios/alterar/`,dados); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao atualizar o registro');
    }
};

const deleteById = async(id: string): Promise<void | Error> => {
    try {
        await Api.delete<IDetalheExercicio>(`/api/exercicios/deletar/${id}`); 
    } catch (error) {
        console.error(error);
        return new Error( (error as {message:string}).message ||   'Erro ao deletar o registro');
    } 
};


export const ExerciciosService = {
    getAll,
    getById,
    create,
    createList,
    updateById,
    deleteById,
}