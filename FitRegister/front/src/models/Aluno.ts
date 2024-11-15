import { Plano } from './Plano';
import { Usuario } from "./Usuario";

export interface Aluno extends Usuario {
    planoId?: string;
    plano?: Plano;
}