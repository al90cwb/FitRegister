
import { useEffect, useRef, useState } from "react";
import {  useNavigate, useParams } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography } from "@mui/material";

import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { ExerciciosService, IDetalheExercicio } from "../../shared/services/api/treinos/TreinosService";
import { VTextField , VForm, useVForm} from "../../shared/forms";


import React from 'react';
import { Form } from "@unform/web";



export const DetalheDeExercicio: React.FC = () => {

    const{ id = "novo"} = useParams<'id'>();
    const navigate = useNavigate();

    const {fomrRef, save,isSaveAnsClose: isSaveAndClose} = useVForm();

    const  [isLoading,setIsLoading] = useState(false);
    const  [nome,setIsNome] = useState('');

    
    useEffect(()=>{
        if(id !== 'novo'){
            setIsLoading(true);

            ExerciciosService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error ){
                       alert(result.message)
                       navigate('/exercicios');
                    }else{
                        setIsNome(result.nome!);
                        console.log(result );
                        fomrRef.current?.setData(result);
                    };
                });
        }else{
            fomrRef.current?.setData({
                nome:'',
                descricao:'',
                grupoMuscular:'',
                repeticoes: '',
                tempoDescanso: '',
                criadoEm: '',
            })
        }


    },[id]);

    const handleSave = (dados : IDetalheExercicio) => {
        setIsLoading(true);


        if (!dados.nome || dados.nome.length < 3) {
            fomrRef.current?.setFieldError('nome','O campo precisa ser prenchido');
            setIsLoading(false);
            return
        }

        if (id == 'novo'){

            ExerciciosService.create(dados)
                .then((result) =>  {
                        setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/exercicios')
                            }else{
                                navigate(`/exercicios/detalhe/${result}`);
                            }
                        }
                })
        
        }else{

            const updatedData = { ...dados, id };  // Adiciona o id aos dados
            console.log(updatedData);
            
            ExerciciosService.updateById(updatedData)
                .then((result) =>  {
                    setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/exercicios')
                            }
                        }
                })

        }
    };

    const handleDelete = (id : string  ) => {
        // eslint-disable-next-line no-restricted-globals
        if (confirm( 'Realmente deseja apagar?') ){
            ExerciciosService.deleteById(id)
            .then(result => {
                if (result instanceof Error){
                    alert (result.message);
                }else{
                    navigate('/exercicios');
                    alert('Registro apagado com sucesso!')
                }
            });
        }
    }
    
    return(
        <LayoutBaseDePagina 
            titulo={id ==='novo' ? 'Novo Treino' : nome}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    mostarBotaoNovo={id !== 'novo'}
                    mostarBotaoApagar={id !== 'novo'}
                    aoClicarEmSalvar={save}
                    aoClicarEmApagar={() =>handleDelete(id)}
                    aoClicarEmNovo={() => navigate('/exercicios/detalhe/novo')}
                    aoClicarEmVoltar={() => navigate('/exercicios')}

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
                            <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                            <VTextField 
                                fullWidth
                                label="Nome do Treino"
                                name='nome'
                                disabled={isLoading}
                                onChange={e => setIsNome(e.target.value)}
                            />
                            </Grid>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                            <VTextField 
                                fullWidth
                                label="Descrição do Treino"
                                name='descricao'
                                disabled={isLoading}
                                onChange={e => setIsNome(e.target.value)}
                            />
                            </Grid>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                            <VTextField 
                                fullWidth
                                label="Grupo muscular"
                                name='grupoMuscular'
                                disabled={isLoading}
                                onChange={e => setIsNome(e.target.value)}
                            />
                            </Grid>
                        </Grid>


                    </Grid>
        
                </Box>
            </Form> 

        </LayoutBaseDePagina>
    );
};