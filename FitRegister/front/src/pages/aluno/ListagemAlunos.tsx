import { useSearchParams } from "react-router-dom"
import { FerramentasDaListagem } from "../../shared/components"
import { LayoutBaseDePagina } from "../../shared/layouts"
import { useEffect, useMemo, useState } from "react";
import { AlunosService, IListagemAlunos  } from "../../shared/services/api/alunos/AlunosService";
import { useDebounce } from "../../shared/hooks";
import { LinearProgress, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@mui/material";


export const ListagemAlunos : React.FC = () => {
    const [searchParams , setSearchParams] = useSearchParams();
    const {debounce} = useDebounce();

    const [rows, setRows] = useState<IListagemAlunos[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [totaCount, setTotalCount] = useState(0);


    const busca = useMemo(() =>{
        return searchParams.get('busca') || '';
    },[searchParams] ) ;

    useEffect(() => {
        setIsLoading(true);

        debounce(() => {


            AlunosService.getAll(1,busca)
            .then((result) => {
                setIsLoading(false);

                if (result instanceof  Error){
                    alert(result.message)
                }else{
                    console.log(result);

                    setTotalCount(result.totalCount);
                    setRows(result.data);

                }
            }) 


        });
        

        
    },[busca]);
    

    return(
        <LayoutBaseDePagina 
        titulo='Lista de Alunos'
        barraDeFerramentas={
            <FerramentasDaListagem
                mostrarInputBusca
                textoDaBusca={busca}
                textoBotaoNovo="Novo"
                aoMudarTextoDaBusca={texto => setSearchParams({busca: texto}, {replace: true} )} //replace impede que faça varias rotas
            />
        }
        >
            <TableContainer component={Paper} variant="outlined"  sx={{m: 1,width: 'auto'}}>

                <Table>


                    <TableHead>
                        <TableRow>
                            <TableCell>Ações</TableCell>
                            <TableCell>Nome Completo</TableCell>
                            <TableCell>email</TableCell>
                        </TableRow>
                    </TableHead>

                    
                    <TableBody>
                        {rows.map(row =>(
                            <TableRow key= {row.id}>
                            <TableCell>Ações</TableCell>
                            <TableCell>{row.nome}</TableCell>
                            <TableCell>{row.email}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>

                    <TableFooter>
                        {isLoading && (
                            <TableRow>
                                <TableCell colSpan={3}>                               
                                    <LinearProgress variant="indeterminate"/>
                                 </TableCell>
                            </TableRow>
                        )}
                    </TableFooter>


                </Table>
            </TableContainer>

        </LayoutBaseDePagina>
        
    )
}