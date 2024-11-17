import { createTheme } from  '@mui/material';
import { indigo, purple } from '@mui/material/colors';

export const DarkTheme = createTheme({
    //palleta de cores
    palette: {
        mode: 'dark',

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
            default: "#202124",//preto
            paper: '#303134',//branco
        }
    },
    typography:{
        allVariants:{
            color: 'white',
        }
    }
})