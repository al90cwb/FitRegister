import { Routes , Route , Navigate } from "react-router-dom";
import { useAppThemeContext,useDrawerContext } from "../shared/context";
import { useEffect } from "react";
import { 
    Dashboard,
    ListagemAlunos,
    DetalheDeAluno,
    DetalheDePlano,
    ListagemPlanos
 } from "../pages";
import { ListagemProfessores } from "../pages/professor/ListagemProfessores";
import { DetalheDeProfessor } from "../pages/professor/DetalheDeProfessor";
import { DetalheDeExercicio } from "../pages/exercicio/DetalheDeExercicio";
import { ListagemExercicios } from "../pages/exercicio/ListagemDeExercicio";
import { VisualizarAluno } from "../pages/aluno/VisualizarAluno";
import { Login } from "../pages/login/Login";
import { VisualizarProfessor } from "../pages/professor/VisualizarProfessor";

export const AppRoutes = ( ) =>{
    const { setDrawerOptions} = useDrawerContext();
    



    //aqui configura os menus de navegação
    useEffect(() =>{
        setDrawerOptions([
            {
                icon: 'home',
                label:'Pagina Inicial',
                path: '/pagina-inicial'
            },
            {
                icon: 'people',
                label:'Alunos',
                path: '/alunos'
            },
            {
                icon: 'fitness_center',
                label:'Exercicios',
                path: '/exercicios'
            },
            {
                icon: 'folder',
                label:'Planos',
                path: '/planos'
            },
            {
                icon: 'people',
                label:'Professores',
                path: '/professores'
            }
        ]);
    },[]);


    //aqui configura as rotas de navegação
    return (
        <Routes>

            <Route path="/login" element={<Login />} />
            <Route path="/pagina-inicial" element = {<Dashboard/> } />

            <Route path="/alunos" element = {<ListagemAlunos/> } />
            <Route path="/alunos/visualizar/:id" element={<VisualizarAluno />} />
            <Route path="/alunos/detalhe/:id" element = {<DetalheDeAluno/> } />

            <Route path="/planos" element = {<ListagemPlanos/> } />
            <Route path="/planos/detalhe/:id" element = {<DetalheDePlano/> } />

            <Route path="/exercicios" element = {<ListagemExercicios/> } />
            <Route path="/exercicios/detalhe/:id" element = {<DetalheDeExercicio/> } />

            <Route path="/professores" element = {<ListagemProfessores/> } />
            <Route path="/professores/visualizar/:id" element={<VisualizarProfessor />} />
            <Route path="/professores/detalhe/:id" element = {<DetalheDeProfessor/> } />

            <Route path="*" element = {<Navigate to  ="/pagina-inicial" />} />

        </Routes>
    );
}