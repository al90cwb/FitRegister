
import { useEffect, useRef, useState } from "react";
import {  useNavigate, useParams } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography } from "@mui/material";
import * as yup from 'yup';

import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { ProfessoresService, IDetalheProfessores } from "../../shared/services/api/professores/ProfessoresService";
import { VTextField , VForm, useVForm} from "../../shared/forms";


import React from 'react';
import { Form } from "@unform/web";



// const formValidationSchema : yup.SchemaOf <IDetalheProfessor> = yup.object().shape({
//     nome : yup.string().required().min(3),
//     email : yup.string().required().email(),
//     planoId : yup.string().required(),
// });


export const DetalheDeProfessor: React.FC = () => {

    const{ id = "novo"} = useParams<'id'>();
    const navigate = useNavigate();

    const {fomrRef, save, saveAndClose, isSaveAndNew,isSaveAnsClose: isSaveAndClose} = useVForm();

    const  [isLoading,setIsLoading] = useState(false);
    const  [nome,setIsNome] = useState('');

    
    useEffect(()=>{
        if(id !== 'novo'){
            setIsLoading(true);

            ProfessoresService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error ){
                       alert(result.message)
                       navigate('/professors');
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
            })
        }


    },[id]);

    const handleSave = (dados : IDetalheProfessores) => {
        setIsLoading(true);


        if (dados.nome.length <3  ) {
            fomrRef.current?.setFieldError('nome','O campo precisa ser prenchido');
            setIsLoading(false);
            return
        }

        if (id == 'novo'){

            ProfessoresService.create(dados)
                .then((result) =>  {
                        setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/professors')
                            }else{
                                navigate(`/professors/detalhe/${result}`);
                            }
                        }
                })
        
        }else{

            const updatedData = { ...dados, id };  // Adiciona o id aos dados
            console.log(updatedData);
            
            ProfessoresService.updateById(updatedData)
                .then((result) =>  {
                    setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            if(isSaveAndClose()){
                                navigate('/professors')
                            }
                        }
                })

        }
    };

    const handleDelete = (id : string  ) => {
        // eslint-disable-next-line no-restricted-globals
        if (confirm( 'Realmente deseja apagar?') ){
            ProfessoresService.deleteById(id)
            .then(result => {
                if (result instanceof Error){
                    alert (result.message);
                }else{
                    navigate('/professors');
                    alert('Registro apagado com sucesso!')
                }
            });
        }
    }
    
    return(
        <LayoutBaseDePagina 
            titulo={id ==='novo' ? 'Novo Professor' : nome}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    mostarBotaoNovo={id !== 'novo'}
                    mostarBotaoApagar={id !== 'novo'}

                    aoClicarEmSalvar={save}
                    aoClicarEmApagar={() =>handleDelete(id)}
                    aoClicarEmNovo={() => navigate('/professors/detalhe/novo')}
                    aoClicarEmVoltar={() => navigate('/professores')}

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

                    </Grid>
        
                </Box>
            </Form> 

        </LayoutBaseDePagina>
    );
};