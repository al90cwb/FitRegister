
import { useEffect, useRef, useState } from "react";
import {  useNavigate, useParams } from "react-router-dom";


import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { AlunosService, IDetalheAluno } from "../../shared/services/api/alunos/AlunosService";
import { VTextField } from "../../shared/forms";
import { FormHandles } from "@unform/core";
import { Form } from '@unform/web';


import React from 'react';

export const DetalheDeAluno: React.FC = () => {

    const{ id = "novo"} = useParams<'id'>();
    const navigate = useNavigate();

    const fomrRef = useRef<FormHandles>(null);

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
        };
    },[id]);

    const handleSave = (dados : IDetalheAluno) => {
        setIsLoading(true);
        if (id == 'novo'){

            AlunosService.create(dados)
                .then((result) =>  {
                        setIsLoading(false);
                        if(result instanceof Error){
                            alert(result.message);
                        }else{
                            navigate(`/alunos/detalhe/${result}`);
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
                        navigate('/alunos');
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
                    //mostarBotaoSalvarEFechar
                    mostarBotaoNovo={id !== 'novo'}
                    mostarBotaoApagar={id !== 'novo'}

                    aoClicarEmSalvar={() => fomrRef.current?.submitForm()}
                    aoClicarEmSalvarEFechar={() => fomrRef.current?.submitForm()}
                    aoClicarEmApagar={() =>handleDelete(id)}
                    aoClicarEmNovo={() => navigate('/alunos/detalhe/novo')}
                    aoClicarEmVoltar={() => navigate('/alunos')}

                />
            }
        >

            
            <Form ref={fomrRef} onSubmit={handleSave}>

                <VTextField placeholder="nome" name='nome'/>
                <VTextField placeholder="Endereço" name='endereco'/>
                <VTextField placeholder="Telefone" name='telefone'/>
                <VTextField placeholder="email" name='email'/>
                <VTextField placeholder="Senha" name='senha' />
                <VTextField placeholder="ID do plano" name='planoId'/>

            </Form> 

        </LayoutBaseDePagina>
    );
};