
import { useEffect, useRef, useState } from "react";
import {  useNavigate, useParams } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography } from "@mui/material";
import * as yup from 'yup';

import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { AlunosService, IDetalheAluno } from "../../shared/services/api/alunos/AlunosService";
import { VTextField , VForm, useVForm} from "../../shared/forms";


import React from 'react';
import { Form } from "@unform/web";



// const formValidationSchema : yup.SchemaOf <IDetalheAluno> = yup.object().shape({
//     nome : yup.string().required().min(3),
//     email : yup.string().required().email(),
//     planoId : yup.string().required(),
// });


export const DetalheDeAluno: React.FC = () => {

    const{ id = "novo"} = useParams<'id'>();
    const navigate = useNavigate();

    const {fomrRef, save, saveAndClose, isSaveAndNew,isSaveAnsClose: isSaveAndClose} = useVForm();

    const  [isLoading,setIsLoading] = useState(false);
    const  [nome,setIsNome] = useState('');

    
    useEffect(()=>{
        if(id !== 'novo'){
            setIsLoading(true);

            AlunosService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error ){
                       alert(result.message)
                       navigate('/alunos');
                    }else{
                        setIsNome(result.nome!);
                        console.log(result );
                        fomrRef.current?.setData(result);
                    };
                });
        }else{
            fomrRef.current?.setData({
                nome:'',
                email:'',
                telefone: '',
                endereco:'',
                senha: '',
                planoId: '',
            })
        }


    },[id]);

    const handleSave = (dados : IDetalheAluno) => {
        setIsLoading(true);


        if (dados.nome.length <3  ) {
            fomrRef.current?.setFieldError('nome','O campo precisa ser prenchido');
            setIsLoading(false);
            return
        }

        if (id == 'novo'){

            AlunosService.create(dados)
                .then((result) =>  {
                        setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/alunos')
                            }else{
                                navigate(`/alunos/detalhe/${result}`);
                            }
                        }
                })
        
        }else{

            const updatedData = { ...dados, id };  // Adiciona o id aos dados
            console.log(updatedData);
            
            AlunosService.updateById(updatedData)
                .then((result) =>  {
                    setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/alunos')
                            }
                        }
                })

        }
    };

    const handleDelete = (id : string  ) => {
        // eslint-disable-next-line no-restricted-globals
        if (confirm( 'Realmente deseja apagar?') ){
            AlunosService.deleteById(id)
            .then(result => {
                if (result instanceof Error){
                    alert (result.message);
                }else{
                    navigate('/alunos');
                    alert('Registro apagado com sucesso!')
                }
            });
        }
    }
    
    return(
        <LayoutBaseDePagina 
            titulo={id ==='novo' ? 'Novo Aluno' : nome}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    mostarBotaoSalvarEFechar
                    mostarBotaoNovo={id !== 'novo'}
                    mostarBotaoApagar={id !== 'novo'}

                    aoClicarEmSalvar={save}
                    aoClicarEmSalvarEFechar={saveAndClose}
                    aoClicarEmApagar={() =>handleDelete(id)}
                    aoClicarEmNovo={() => navigate('/alunos/detalhe/novo')}
                    aoClicarEmVoltar={() => navigate('/alunos')}

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
                                label="Nome Completo"
                                name='nome'
                                disabled={isLoading}
                                onChange={e => setIsNome(e.target.value)}
                            />
                            </Grid>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                                <VTextField 
                                fullWidth
                                label="Endereço" 
                                name='endereco'
                                disabled={isLoading}
                            />
                            </Grid>
                        </Grid>
                
                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                            <VTextField 
                                fullWidth
                                label="Telefone" 
                                name='telefone'
                                disabled={isLoading}
                            />
                            </Grid>
                        </Grid>
                    
                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                            <VTextField 
                                label="E-mail" 
                                name='email'
                                disabled={isLoading}
                            />
                            </Grid>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                            <VTextField 
                                fullWidth
                                label="Senha" 
                                name='senha'
                                disabled={isLoading}
                                />
                            </Grid>
                        </Grid>

                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                            <VTextField 
                                fullWidth
                                label="Plano" 
                                name='planoId'
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