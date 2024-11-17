import { Box, Button, Divider, Icon, Paper, useTheme } from "@mui/material";


interface IFerramentasDeDetalheProps{
    textoBotaoNovo?: string;

    mostarBotaoNovo?: boolean;
    mostarBotaoVoltar?: boolean;
    mostarBotaoApagar?: boolean;
    mostarBotaoSalvar?: boolean;
    mostarBotaoSalvarEFechar?: boolean;

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

    aoClicarEmNovo,
    aoClicarEmVoltar,
    aoClicarEmApagar,
    aoClicarEmSalvar,
    aoClicarEmSalvarEFechar,

}) => {

    
    const theme = useTheme()
    
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

            {mostarBotaoSalvar && (<Button
            variant='contained'
            color='primary'
            disableElevation
            onClick={aoClicarEmSalvar}
            startIcon={<Icon>save</Icon>}
            >Salvar</Button>)}

            {mostarBotaoSalvarEFechar &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmSalvarEFechar}
            startIcon={<Icon>save</Icon>}
            >Salvar e Fechar</Button>)}

            { mostarBotaoApagar &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmApagar}
            startIcon={<Icon>delete</Icon>}
            >Apagar</Button>)}

            { mostarBotaoNovo &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmNovo}
            startIcon={<Icon>add</Icon>}
            >{textoBotaoNovo}</Button>)}

            <Divider variant='middle' orientation='vertical'/>
            
            { mostarBotaoVoltar &&(<Button
            variant='outlined'
            color='primary'
            disableElevation
            onClick={aoClicarEmVoltar}
            startIcon={<Icon>arrow_back</Icon>}
            >Voltar</Button>)}

        </Box>
    ) ;
}
