import { useNavigate, useSearchParams } from "react-router-dom"
import { FerramentasDaListagem } from "../../shared/components"
import { LayoutBaseDePagina } from "../../shared/layouts"
import { useEffect, useMemo, useState } from "react";
import { PlanosService, IListagemPlanos  } from "../../shared/services/api/planos/PlanosService";
import { useDebounce } from "../../shared/hooks";
import { Icon, IconButton, LinearProgress, Pagination, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@mui/material";
import { Envioriment } from "../../shared/environment";


export const ListagemPlanos : React.FC = () => {
    
    const [searchParams , setSearchParams] = useSearchParams();
    const {debounce} = useDebounce();
    const navigate = useNavigate();

    const [rows, setRows] = useState<IListagemPlanos[]>([]);
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


            PlanosService.getAll(pagina,busca)
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
    
    /* eslint-disable no-restricted-globals */
    const handleDelete = (id : string  ) => {
        if (confirm( 'Realmente deseja apagar?') ){
            PlanosService.deleteById(id)
            .then(result => {
                if (result instanceof Error){
                    alert (result.message);
                }else{
                    window.location.reload(); // Recarrega a página
                    alert('Registro apagado com sucesso!')
                }
            });
        }
    }

    return(
        <LayoutBaseDePagina 
        titulo='Lista de Planos'
        barraDeFerramentas={
            <FerramentasDaListagem
                mostrarInputBusca
                textoDaBusca={busca}
                textoBotaoNovo="Novo"
                aoClicarEmNovo={() => navigate("/planos/detalhe/novo") }
                aoMudarTextoDaBusca={texto => setSearchParams({busca: texto, pagina:'1'}, {replace: true} )} //replace impede que faça varias rotas
            />
        }
        >
            <TableContainer component={Paper} variant="outlined"  sx={{m: 1,width: 'auto'}}>

                <Table>


                    <TableHead>
                        <TableRow>
                            <TableCell>Ações</TableCell>
                            <TableCell>Nome do Plano</TableCell>
                        </TableRow>
                    </TableHead>

                    
                    <TableBody>
                        {rows.map(row =>(
                            <TableRow key= {row.id}>
                            <TableCell>
                                <IconButton size="small" onClick={()=> handleDelete(row.id!)}>
                                    <Icon>delete</Icon>
                                </IconButton>
                                <IconButton size="small" onClick={()=> navigate(`/planos/detalhe/${row.id!}`)}>
                                    <Icon>edit</Icon>
                                </IconButton>

                            </TableCell>
                            <TableCell>{row.nomePlano}</TableCell>
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