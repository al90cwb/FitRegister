import { useSearchParams } from "react-router-dom"
import { FerramentasDaListagem } from "../../shared/components"
import { LayoutBaseDePagina } from "../../shared/layouts"
import { useMemo } from "react";


export const ListagemAlunos : React.FC = () => {
    const [searchParams , setSearchParams] = useSearchParams();

    const busca = useMemo(() =>{
        return searchParams.get('busca') || '';
    },[searchParams] ) ;
    

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

        </LayoutBaseDePagina>
        
    )
}