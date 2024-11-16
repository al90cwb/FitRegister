import { Routes , Route , Navigate } from "react-router-dom";
import { Button } from '@mui/material';
import { useAppThemeContext } from "../shared/context";

export const AppRoutes = ( ) =>{
    const {toggleTheme } = useAppThemeContext();


    return (
        <Routes>
            <Route path="/pagina-inicial"  
                element = {<Button
                    variant='contained'
                    onClick={toggleTheme}
                    color='primary'
                >Teste</Button> } />
            <Route path="*" element = {<Navigate to  ="/pagina-inicial" />} />
        </Routes>
    );
}