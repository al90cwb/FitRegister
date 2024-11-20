import { createTheme } from  '@mui/material';
import { indigo, purple } from '@mui/material/colors';

export const LightTheme = createTheme({
    //palleta de cores
    palette: {
        primary:{
            main: purple[500],
            dark: purple[700],
            light: purple[400],
            contrastText: '#ffffff'
        },//cor primaria
        
        secondary:{
            main: indigo[500],
            dark: indigo[400],
            light: indigo[300],
            contrastText: '#ffffff'
        },//cor secundaria

        background:{
            default: "#f7f6f3",//cinza 
            paper: '#ffffff',//branco
        }
    }
})