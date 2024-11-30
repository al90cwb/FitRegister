
import { useEffect, useRef, useState } from "react";
import {  useNavigate, useParams } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography } from "@mui/material";
import * as yup from 'yup';

import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { PlanosService, IDetalhePlano } from "../../shared/services/api/planos/PlanosService";
import { VTextField , VForm, useVForm} from "../../shared/forms";


import React from 'react';
import { Form } from "@unform/web";



// const formValidationSchema : yup.SchemaOf <IDetalhePlano> = yup.object().shape({
//     nome : yup.string().required().min(3),
//     email : yup.string().required().email(),
//     planoId : yup.string().required(),
// });


export const DetalheDePlano: React.FC = () => {

    const{ id = "novo"} = useParams<'id'>();
    const navigate = useNavigate();

    const {fomrRef, save, saveAndClose, isSaveAndNew,isSaveAnsClose: isSaveAndClose} = useVForm();

    const  [isLoading,setIsLoading] = useState(false);
    const  [nome,setIsNome] = useState('');

    
    useEffect(()=>{
        if(id !== 'novo'){
            setIsLoading(true);

            PlanosService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error ){
                       alert(result.message)
                       navigate('/planos');
                    }else{
                        setIsNome(result.nomePlano!);
                        console.log(result );
                        fomrRef.current?.setData(result);
                    };
                });
        }else{
            fomrRef.current?.setData({
                id:'',
                nomePlano: '',
                valor:'',
                parcelas: '',
            })
        }


    },[id]);

    const handleSave = (dados : IDetalhePlano) => {
        setIsLoading(true);


        if (!dados.nomePlano || dados.nomePlano.length < 3) {
            fomrRef.current?.setFieldError('nome','O campo precisa ser prenchido');
            setIsLoading(false);
            return
        }

        if (id == 'novo'){

            PlanosService.create(dados)
                .then((result) =>  {
                        setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/planos')
                            }else{
                                navigate(`/planos/detalhe/${result}`);
                            }
                        }
                })
        
        }else{

            const updatedData = { ...dados, id };  // Adiciona o id aos dados
            console.log(updatedData);
            
            PlanosService.updateById(updatedData)
                .then((result) =>  {
                    setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/planos')
                            }
                        }
                })

        }
    };

    const handleDelete = (id : string  ) => {
        // eslint-disable-next-line no-restricted-globals
        if (confirm( 'Realmente deseja apagar?') ){
            PlanosService.deleteById(id)
            .then(result => {
                if (result instanceof Error){
                    alert (result.message);
                }else{
                    navigate('/planos');
                    alert('Registro apagado com sucesso!')
                }
            });
        }
    }
    
    return(
        <LayoutBaseDePagina 
            titulo={id ==='novo' ? 'Novo Plano' : nome}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    mostarBotaoNovo={id !== 'novo'}
                    mostarBotaoApagar={id !== 'novo'}

                    aoClicarEmSalvar={save}
                    aoClicarEmApagar={() =>handleDelete(id)}
                    aoClicarEmNovo={() => navigate('/planos/detalhe/novo')}
                    aoClicarEmVoltar={() => navigate('/planos')}

                />
            }
        >

            
            <Form ref={fomrRef} onSubmit={handleSave} placeholder={undefined} onPointerEnterCapture={undefined} onPointerLeaveCapture={undefined} >
                <Box margin={1} display="flex" flexDirection="column" component={Paper} variant="outlined">

                    <Grid container direction="column" padding={2} spacing={2}>

                        {isLoading &&(
                            <Grid item>
                                <LinearProgress variant="indeterminate"/>
                            </Grid>
                        )}

                        <Grid item>
                            <Typography variant="h6">Geral</Typography>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                            <VTextField 
                                fullWidth
                                label="Nome do Plano"
                                name='nomePlano'
                                disabled={isLoading}
                                onChange={e => setIsNome(e.target.value)}
                            />
                            </Grid>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                                <VTextField 
                                fullWidth
                                label="Valor" 
                                name='valor'
                                disabled={isLoading}
                            />
                            </Grid>
                        </Grid>
                
                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                            <VTextField 
                                fullWidth
                                label="Parcelas" 
                                name='parcelas'
                                disabled={isLoading}
                            />
                            </Grid>
                        </Grid>

                    </Grid>
        
                </Box>
            </Form> 

        </LayoutBaseDePagina>
    );
};