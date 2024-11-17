import { Routes , Route , Navigate } from "react-router-dom";
import { useAppThemeContext,useDrawerContext } from "../shared/context";
import { useEffect } from "react";
import { Dashboard } from "../pages";

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
        ]);
    },[]);


    //aqui configura as rotas de navegação
    return (
        <Routes>


            <Route path="/pagina-inicial" element = {<Dashboard/> } />



            <Route path="*" element = {<Navigate to  ="/pagina-inicial" />} />

        </Routes>
    );
}