import { TramSharp } from "@mui/icons-material";
import { Avatar, Box, Divider, Drawer ,Icon,List,ListItemButton,ListItemIcon,ListItemText,useMediaQuery,useTheme } from "@mui/material";
import { createContext, useCallback , useState, useMemo, useContext} from "react";
import { useDrawerContext } from "../../context";


interface IappMenuLateralProvideProps{
    children : React.ReactNode
}

export const MenuLateral : React.FC<IappMenuLateralProvideProps> = ({children}) => {
    const theme  = useTheme();
    const smDown = useMediaQuery(theme.breakpoints.down('sm'));
    
    const { isDrawerOpen} = useDrawerContext();


    return(
        <>
            <Drawer open={isDrawerOpen} variant={smDown ? 'temporary' : 'permanent'}>
                <Box width={theme.spacing(28) } height="100%" display="flex" flexDirection="column">

                    <Box width="100%" height={theme.spacing(20)} display="flex" alignItems="center" justifyContent="center">
                        <Avatar
                            sx={{height: theme.spacing(12), width:  theme.spacing(12) }}
                            src="https://pbs.twimg.com/profile_images/1085239615689293825/XLmISw5p_400x400.jpg" />
                    </Box>

                    <Divider/>

                    <Box flex={1}>
                        <List component="nav">

                            <ListItemButton>
                                <ListItemIcon>
                                    <Icon>home</Icon>
                                </ListItemIcon>
                                <ListItemText primary="Pagina Inicial" />
                            </ListItemButton>


                        </List>

                        
                    </Box>

                </Box>
            </Drawer>


            <Box height="100vh" marginLeft={ smDown ? 0: theme.spacing(28)} >
                {children}
            </Box>
        </>
    );
};