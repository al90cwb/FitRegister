import { useSearchParams } from "react-router-dom"
import { FerramentasDaListagem } from "../../shared/components"
import { LayoutBaseDePagina } from "../../shared/layouts"
import { useEffect, useMemo, useState } from "react";
import { AlunosService, IListagemAlunos  } from "../../shared/services/api/alunos/AlunosService";
import { useDebounce } from "../../shared/hooks";
import { LinearProgress, Pagination, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@mui/material";
import { Envioriment } from "../../shared/environment";


export const ListagemAlunos : React.FC = () => {
    const [searchParams , setSearchParams] = useSearchParams();
    const {debounce} = useDebounce();

    const [rows, setRows] = useState<IListagemAlunos[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [totalCount, setTotalCount] = useState(0);


    const busca = useMemo(() =>{
        return searchParams.get('busca') || '';
    },[searchParams] ) ;

    const pagina = useMemo(() =>{
        return Number(searchParams.get('pagina') || "1");
    },[searchParams] ) ;

    useEffect(() => {
        setIsLoading(true);

        debounce(() => {


            AlunosService.getAll(pagina,busca)
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
                aoMudarTextoDaBusca={texto => setSearchParams({busca: texto, pagina:'1'}, {replace: true} )} //replace impede que faça varias rotas
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
                        
                        
                        {(totalCount>0 && totalCount>Envioriment.LIMITE_DE_LINHAS) && (
                            <TableRow>
                                <TableCell colSpan={3}>                               
                                    <Pagination
                                     page={pagina}
                                     count-={Math.ceil(totalCount/Envioriment.LIMITE_DE_LINHAS)}
                                     onChange={(_,newPage)=> setSearchParams({busca, pagina: newPage.toString()}, {replace: true} )  }
                                     />
                                 </TableCell>
                            </TableRow>
                        )}

                    </TableFooter>


                </Table>
            </TableContainer>

        </LayoutBaseDePagina>
        
    )
}