import { Routes, Route, Navigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { 
    Dashboard,
    ListagemAlunos,
    DetalheDeAluno,
    DetalheDePlano,
    ListagemPlanos,
    Cadastrar
} from "../pages";
import { ListagemProfessores } from "../pages/professor/ListagemProfessores";
import { DetalheDeProfessor } from "../pages/professor/DetalheDeProfessor";
import { DetalheDeExercicio } from "../pages/treinos/DetalheDeTreino";
import { ListagemExercicios } from "../pages/treinos/ListagemDeTreino";
import { VisualizarAluno } from "../pages/aluno/VisualizarAluno";
import { Login } from "../pages/login/Login";
import { VisualizarProfessor } from "../pages/professor/VisualizarProfessor";
import { useDrawerContext } from "../shared/context";

export const AppRoutes = () => {
    const { setDrawerOptions } = useDrawerContext();
    const isAuthenticated = localStorage.getItem("isAuthenticated") === "true";
    const userRole = localStorage.getItem("userRole");

    useEffect(() => {
        if (isAuthenticated) {
            if (userRole === "Professor") {
                setDrawerOptions([
                    { icon: "home", label: "Página Inicial", path: "/pagina-inicial" },
                    { icon: "people", label: "Alunos", path: "/alunos" },
                    { icon: "fitness_center", label: "Treinos", path: "/exercicios" },
                    { icon: "folder", label: "Planos", path: "/planos" },
                    { icon: "people", label: "Professores", path: "/professores" },
                ]);
            }
        } else {
            setDrawerOptions([]);
        }
    }, [isAuthenticated, userRole, setDrawerOptions]);

    return (
        <Routes>
            {/* Redirecionamento baseado na autenticação */}
            <Route path="/" element={isAuthenticated ? <Navigate to="/pagina-inicial" /> : <Navigate to="/pagina-inicial" />} />

            {/* Rota de login */}
            <Route path="/login" element={<Login />} />
            
            {/* Rotas protegidas */}
            <Route path="/pagina-inicial" element={isAuthenticated ? <Dashboard /> : <Navigate to="/login" />} />
            <Route path="/alunos" element={isAuthenticated ? <ListagemAlunos /> : <Navigate to="/login" />} />
            <Route path="/alunos/visualizar/:id" element={isAuthenticated ? <VisualizarAluno /> : <Navigate to="/login" />} />
            <Route path="/alunos/detalhe/:id" element={isAuthenticated ? <DetalheDeAluno /> : <Navigate to="/login" />} />
            <Route path="/planos" element={isAuthenticated ? <ListagemPlanos /> : <Navigate to="/login" />} />
            <Route path="/planos/detalhe/:id" element={isAuthenticated ? <DetalheDePlano /> : <Navigate to="/login" />} />
            <Route path="/exercicios" element={isAuthenticated ? <ListagemExercicios /> : <Navigate to="/login" />} />
            <Route path="/exercicios/detalhe/:id" element={isAuthenticated ? <DetalheDeExercicio /> : <Navigate to="/login" />} />
            <Route path="/professores" element={isAuthenticated ? <ListagemProfessores /> : <Navigate to="/login" />} />
            <Route path="/professores/visualizar/:id" element={isAuthenticated ? <VisualizarProfessor /> : <Navigate to="/login" />} />
            <Route path="/professores/detalhe/:id" element={isAuthenticated ? <DetalheDeProfessor /> : <Navigate to="/login" />} />
            <Route path="/cadastrar" element={<Cadastrar />} />
   
            {/* Redirecionamento para login caso a rota seja inválida */}
            <Route path="*" element={<Navigate to="/login" />} />
        </Routes>
    );
};
