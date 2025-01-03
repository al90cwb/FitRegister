import { Avatar, Box, Divider, Drawer ,Icon,List,ListItemButton,ListItemIcon,ListItemText,useMediaQuery,useTheme } from "@mui/material";
import { useAppThemeContext, useDrawerContext } from "../../context";
import { useMatch, useNavigate, useResolvedPath } from "react-router-dom";
import { logo192, logo512 } from "../../images";



interface IListItemLinkProps {
    to: string;//rota do react para tela onde se quer navegar
    label: string;
    icon: string;
    onClick: (() => void ) | undefined ;//qunado acessar a rota fechar o menu lateral pode receber vazio ou undefined por que tem momento ue na~ço vamos querer fechar
}

const ListItemLink: React.FC<IListItemLinkProps> = ({to, icon,label, onClick }) => {
    const navigate = useNavigate();

    const resolvedPath = useResolvedPath(to);// detro do contexto e interpreta algumas configurações diponiveis
    const match = useMatch({path : resolvedPath.pathname, end : false})//verifica se nossa opção de menu esta selecionada ou não, se diferente de nulo esta na rota certa


    const handleClick = () => {
        navigate(to);
        onClick?.() ;
    }

    return(
        <ListItemButton  selected={!!match} onClick={handleClick}>
            <ListItemIcon>
                <Icon>{icon}</Icon>
                </ListItemIcon>
            <ListItemText primary={label} />
        </ListItemButton>
    )
}

interface IappMenuLateralProvideProps{
    children : React.ReactNode
}

export const MenuLateral : React.FC<IappMenuLateralProvideProps> = ({children}) => {
    const theme  = useTheme();
    const smDown = useMediaQuery(theme.breakpoints.down('sm'));
    
    const { isDrawerOpen,toggleDrawerOpen,drawerOptions} = useDrawerContext();
    const { toggleTheme } = useAppThemeContext();


    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem("isAuthenticated");
        localStorage.removeItem("userRole");
        navigate("/login"); // Redireciona para a tela de login
        window.location.reload(); // Atualiza o estado no App
    };


    return(
        <>
            <Drawer open={isDrawerOpen} variant={smDown ? 'temporary' : 'permanent'} onClose={toggleDrawerOpen}>
                <Box width={theme.spacing(28) } height="100%" display="flex" flexDirection="column">
                    {/*Parte Superior do menu lateral onde tem uma foto - coloquei qualque uma  */}
                    <Box width="100%" height={theme.spacing(20)} display="flex" alignItems="center" justifyContent="center">
                        <Avatar
                            sx={{height: theme.spacing(12), width:  theme.spacing(12) }}
                            src={logo192}
                            />
                    </Box>

                    <Divider/>

                    {/*Menus de Navegação  */}
                    <Box flex={1}>
                        <List component="nav">

                            { drawerOptions.map( drawerOptions =>(
                                <ListItemLink
                                    key={drawerOptions.path}
                                    icon={drawerOptions.icon}
                                    to={drawerOptions.path}
                                    label={drawerOptions.label}
                                    onClick={smDown ? toggleDrawerOpen :  undefined}
                                />
                            ))}

                        </List>
                    </Box>

                    <Box>
                        <List component="nav">
                            <ListItemButton onClick={handleLogout}>
                                <ListItemIcon>
                                    <Icon>logout</Icon>
                                </ListItemIcon>
                                <ListItemText primary="Logout" />
                            </ListItemButton>
                        </List>
                    </Box>

                    <Box>
                        <List component="nav">

                        <ListItemButton   onClick={toggleTheme}>
                            <ListItemIcon>
                                <Icon>dark_mode</Icon>
                                </ListItemIcon>
                            <ListItemText primary="Alternar tema" />
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