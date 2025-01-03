import {  Icon, IconButton, Typography, useTheme } from "@mui/material";
import { Box, useMediaQuery } from "@mui/system";
import { ReactNode } from "react";
import { useDrawerContext } from "../context";


interface ILayoutBaseDePaginaProps{
    titulo?: string;
    children?: ReactNode;
    barraDeFerramentas?: ReactNode;
}


export const LayoutBaseDePagina: React.FC<ILayoutBaseDePaginaProps> = ({children, titulo,barraDeFerramentas}) => {
    
    const theme = useTheme();
    const smDown = useMediaQuery(theme.breakpoints.down('sm'));
    const mdDown = useMediaQuery(theme.breakpoints.down('md'));

    const { toggleDrawerOpen} = useDrawerContext();

    return(
        <Box height="100%" display="flex" flexDirection="column" gap={1}>
            <Box padding={1} display="flex" alignItems="center"  height={theme.spacing(12)}  gap={1} >
                
                { smDown &&(
                    <IconButton onClick={toggleDrawerOpen}>
                        <Icon>menu</Icon>
                    </IconButton>
                )}

                <Typography
                 overflow="hidden"
                 whiteSpace="nowrap" 
                 textOverflow="ellipsis"
                 variant={smDown? 'h5' : mdDown ? 'h4': 'h3'}
                >
                    {titulo} 
                </Typography>

            </Box>

            {barraDeFerramentas &&(
                <Box>
                    {barraDeFerramentas} 
                </Box>
            )}

            <Box flex={1} overflow="auto">
                {children}
            </Box>
        </Box>
    );
};