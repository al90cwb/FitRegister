
import { createContext, useCallback , useState, useMemo, useContext} from "react";
import { ThemeProvider } from "@emotion/react";
import { DarkTheme, LightTheme } from "../themes";
import { Box } from "@mui/material";


interface IThemeContextData{
    themeName: 'light' | 'dark';//colocar todos themas
    toggleTheme: () => void;
}
const ThemeContext = createContext({} as IThemeContextData);

export const useAppThemeContext = () =>{
    return useContext(ThemeContext);
}

interface IappThemeProvideProps{
    children : React.ReactNode
}

export const AppThemeProvider : React.FC<IappThemeProvideProps> = ({ children }) => {
    const [themeName, setThemeName] = useState<'light' | 'dark'>('light');

    const toggleTheme = useCallback(() =>{
        setThemeName(oldThemeName => oldThemeName === 'light' ? 'dark' : 'light');
    } ,[] );

    const theme =  useMemo(() => {
        if (themeName === 'light') return LightTheme;
        return DarkTheme;
    },[themeName] );

    return(
        <ThemeContext.Provider value = {{ themeName ,toggleTheme }}>
            <ThemeProvider theme={theme}>
                <Box width="100vw" height="100vh" bgcolor={theme.palette.background.default}>
                    {children}
                </Box>
            </ThemeProvider>
        </ThemeContext.Provider>
    )
}