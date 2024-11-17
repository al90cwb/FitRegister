import { Routes , Route , Navigate } from "react-router-dom";
import { Button } from '@mui/material';
import { useAppThemeContext,useDrawerContext } from "../shared/context";
import { useEffect } from "react";

export const AppRoutes = ( ) =>{
    const {toggleDrawerOpen, setDrawerOptions} = useDrawerContext();



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


    return (
        <Routes>


            <Route path="/pagina-inicial" element = {<Button variant='contained'   onClick={toggleDrawerOpen}   color='primary'>Toggle Drawer</Button> } />
            <Route path="*" element = {<Navigate to  ="/pagina-inicial" />} />


        </Routes>
    );
}