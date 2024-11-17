import {FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";

export const Dashboard = () => {
    
    return(
        <LayoutBaseDePagina
         titulo= 'Pagina Inicial'
         barraDeFerramentas={(
            <FerramentasDeDetalhe
             mostarBotaoSalvarEFechar
             mostarBotaoSalvarEFecharCarregando
             mostarBotaoVoltar={false}
            />
            
         )}
         >
            Testando
        </LayoutBaseDePagina>
    );
};