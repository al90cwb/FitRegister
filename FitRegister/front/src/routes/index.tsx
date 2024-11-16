import { Routes , Route , Navigate } from "react-router-dom";
import { Button } from '@mui/material';
import { useAppThemeContext,useDrawerContext } from "../shared/context";

export const AppRoutes = ( ) =>{
    const {toggleDrawerOpen} = useDrawerContext();


    return (
        <Routes>


            <Route path="/pagina-inicial"  
                element = {<Button
                    variant='contained'
                    onClick={toggleDrawerOpen}
                    color='primary'
                >Toggle Drawer</Button> } />




            <Route path="*" element = {<Navigate to  ="/pagina-inicial" />} />


        </Routes>
    );
}