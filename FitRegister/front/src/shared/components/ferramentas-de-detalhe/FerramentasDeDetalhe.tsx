import { Box, Button, Divider, Icon, Paper, Skeleton, Typography, useMediaQuery, useTheme } from "@mui/material";


interface IFerramentasDeDetalheProps{
    textoBotaoNovo?: string;

    mostarBotaoNovo?: boolean;
    mostarBotaoVoltar?: boolean;
    mostarBotaoApagar?: boolean;
    mostarBotaoSalvar?: boolean;
    mostarBotaoSalvarEFechar?: boolean;

    
    mostarBotaoNovoCarregando?: boolean;
    mostarBotaoVoltarCarregando?: boolean;
    mostarBotaoApagarCarregando?: boolean;
    mostarBotaoSalvarCarregando?: boolean;
    mostarBotaoSalvarEFecharCarregando?: boolean;

    aoClicarEmNovo?: () => void;
    aoClicarEmVoltar?: () => void;
    aoClicarEmApagar?: () => void;
    aoClicarEmSalvar?: () => void;
    aoClicarEmSalvarEFechar?: () => void;




}

export const FerramentasDeDetalhe: React.FC<IFerramentasDeDetalheProps> = ({
    textoBotaoNovo= 'Novo',

    mostarBotaoNovo = true,
    mostarBotaoVoltar= true,
    mostarBotaoApagar= true,
    mostarBotaoSalvar= true,
    mostarBotaoSalvarEFechar= false,

    
    mostarBotaoSalvarCarregando= false,
    mostarBotaoSalvarEFecharCarregando= false,
    mostarBotaoNovoCarregando= false,
    mostarBotaoVoltarCarregando= false,
    mostarBotaoApagarCarregando= false,

    aoClicarEmNovo,
    aoClicarEmVoltar,
    aoClicarEmApagar,
    aoClicarEmSalvar,
    aoClicarEmSalvarEFechar,

}) => {

    
    const theme = useTheme()
    const smDown = useMediaQuery(theme.breakpoints.down('sm'));
    const mdDown = useMediaQuery(theme.breakpoints.down('md'));

    
    return(
        <Box
        gap={1}
        marginX={1}
        padding={1}
        paddingX={1}
        display="flex" 
        alignItems="center"
        height={theme.spacing(5)}
        component={Paper}
        >

            {(mostarBotaoSalvar && !mostarBotaoSalvarCarregando) && (<Button
            variant='contained'
            color='primary'
            disableElevation
            onClick={aoClicarEmSalvar}
            startIcon={<Icon>save</Icon>}
            >
                <Typography variant='button' whiteSpace='nowrap' textOverflow="ellipsis" overflow="hidden">
                    Salvar
                </Typography>
            </Button>)}

            {mostarBotaoSalvarCarregando &&(
                <Skeleton width={110} height={60}/>
            )}


            {(mostarBotaoSalvarEFechar && !smDown && !mdDown && !mostarBotaoSalvarEFecharCarregando) &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmSalvarEFechar}
            startIcon={<Icon>save</Icon>}
            >
                <Typography variant='button' whiteSpace='nowrap' textOverflow="ellipsis" overflow="hidden">
                    Salvar e Fechar
                </Typography>

            </Button>)}
            
            { (mostarBotaoSalvarEFecharCarregando && !smDown && !mdDown ) &&(
                <Skeleton width={180} height={60}/>
            )}


            { (mostarBotaoApagar && !mostarBotaoApagarCarregando ) &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmApagar}
            startIcon={<Icon>delete</Icon>}
            >
                <Typography variant='button' whiteSpace='nowrap' textOverflow="ellipsis" overflow="hidden">
                    Apagar
                </Typography>
                
            </Button>)}

            {mostarBotaoApagarCarregando&& (
                <Skeleton width={110} height={60}/>
            )}
            

            { (mostarBotaoNovo && !smDown && !mostarBotaoNovoCarregando ) &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmNovo}
            startIcon={<Icon>add</Icon>}
            >
                <Typography variant='button' whiteSpace='nowrap' textOverflow="ellipsis" overflow="hidden">
                   {textoBotaoNovo}
                </Typography>

            </Button>)}
            {(mostarBotaoNovoCarregando &&  !smDown ) &&(
                <Skeleton width={110} height={60}/>
            )}


            { ( mostarBotaoVoltar &&
                (mostarBotaoNovo || mostarBotaoApagar || mostarBotaoSalvar || mostarBotaoSalvarEFechar )
            ) && (
                <Divider variant='middle' orientation='vertical'/>
            )}
            
            
            { (mostarBotaoVoltar && !mostarBotaoVoltarCarregando) &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmVoltar}
            startIcon={<Icon>arrow_back</Icon>}
            >
                <Typography variant='button' whiteSpace='nowrap' textOverflow="ellipsis" overflow="hidden">
                    Voltar
                </Typography>
                
            </Button>)}
            {mostarBotaoVoltarCarregando&&(
                <Skeleton width={110} height={60}/>
            )}


            
        </Box>
    ) ;
}
