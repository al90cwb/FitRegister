import { Aluno } from "./Aluno";

export interface Plano {
    id?: string;
    nomePlano: string;
    valor: number;
    parcelas: number;
    criadoEm?: string;
    alunos: Aluno[];
  }
  