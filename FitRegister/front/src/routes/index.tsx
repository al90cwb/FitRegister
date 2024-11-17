import { Routes , Route , Navigate } from "react-router-dom";
import { useAppThemeContext,useDrawerContext } from "../shared/context";
import { useEffect } from "react";
import { 
    Dashboard,
    ListagemAlunos

 } from "../pages";

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
        ]);
    },[]);


    //aqui configura as rotas de navegação
    return (
        <Routes>


            <Route path="/pagina-inicial" element = {<Dashboard/> } />

            <Route path="/alunos" element = {<ListagemAlunos/> } />



            <Route path="*" element = {<Navigate to  ="/pagina-inicial" />} />

        </Routes>
    );
}