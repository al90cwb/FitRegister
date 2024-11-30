import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography, Select, MenuItem, FormControl, InputLabel } from "@mui/material";
import { Form } from "@unform/web";

import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { AlunosService, IDetalheAluno } from "../../shared/services/api/alunos/AlunosService";
import { PlanosService } from "../../shared/services/api/planos/PlanosService";
import { ExerciciosService } from "../../shared/services/api/treinos/TreinosService";
import { VTextField, useVForm } from "../../shared/forms";

export const DetalheDeAluno: React.FC = () => {
    const { id = "novo" } = useParams<'id'>();
    const navigate = useNavigate();

    const { fomrRef, save, isSaveAndNew, isSaveAnsClose: isSaveAndClose } = useVForm();

    const [isLoading, setIsLoading] = useState(false);
    const [nome, setIsNome] = useState('');
    const [planos, setPlanos] = useState<any[]>([]);
    const [exercicios, setExercicios] = useState<any[]>([]);

    const [planoId, setPlanoId] = useState('');
    const [exercicioId, setExercicioId] = useState('');

    useEffect(() => {
        setIsLoading(true);

        // Carrega planos e exercícios
        PlanosService.getAll()
            .then((result) => {
                if (!(result instanceof Error)) setPlanos(result.data);
            });

        ExerciciosService.getAll()
            .then((result) => {
                if (!(result instanceof Error)) setExercicios(result.data);
            })
            .finally(() => setIsLoading(false));

        if (id !== "novo") {
            setIsLoading(true);

            AlunosService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error) {
                        alert(result.message);
                        navigate('/alunos');
                    } else {
                        setIsNome(result.nome!);
                        fomrRef.current?.setData(result);
                    }
                });
        } else {
            fomrRef.current?.setData({
                nome: '',
                email: '',
                telefone: '',
                endereco: '',
                senha: '',
                planoId: '',
                exercicioId: '',
            });
        }
    }, [id]);

    const handleSave = (dados: IDetalheAluno) => {
        console.log("Plano id: " + planoId);  // Agora planoId estará correto
        console.log("Exercicio id: " + exercicioId);  // Agora exercicioId estará correto
    
        setIsLoading(true);

        if (!dados.nome || dados.nome.length < 3) {
            fomrRef.current?.setFieldError('nome', 'O nome precisa ter pelo menos 3 caracteres');
            setIsLoading(false);
            return;
        }
    
        if (!dados.email || !dados.email.includes('@')) {
            fomrRef.current?.setFieldError('email', 'E-mail inválido');
            setIsLoading(false);
            return;
        }
    
        if (!dados.telefone || dados.telefone.length < 10) {
            fomrRef.current?.setFieldError('telefone', 'Telefone inválido');
            setIsLoading(false);
            return;
        }
        
        if (planoId) { dados.planoId = planoId;}
        if (exercicioId){dados.exercicioId = exercicioId;}
        

        if (id === 'novo') {
            console.log("NOVO " + dados);
            AlunosService.create(dados)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error) {
                        alert(result.message);
                    } else {
                        if (isSaveAndClose()) {
                            navigate('/alunos');
                        } else {
                            navigate(`/alunos/detalhe/${result}`);
                        }
                    }
                });
                
        } else {
            

            AlunosService.updateById({ ...dados, id })
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error) {
                        alert(result.message);
                        console.log("erro");
                    } else {
                        console.log("sem erro");
                        if (isSaveAndClose()) {
                            navigate('/alunos');
                        }
                    }
                });
        }
    };

    const handleDelete = (id: string) => {
        // eslint-disable-next-line no-restricted-globals
        if (confirm('Realmente deseja apagar?')) {
            AlunosService.deleteById(id)
                .then((result) => {
                    if (result instanceof Error) {
                        alert(result.message);
                    } else {
                        navigate('/alunos');
                        alert('Registro apagado com sucesso!');
                    }
                });
        }
    };

    return(
        <LayoutBaseDePagina 
            titulo={id ==='novo' ? 'Novo Aluno' : nome}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    mostarBotaoNovo={id !== 'novo'}
                    mostarBotaoApagar={id !== 'novo'}

                    aoClicarEmSalvar={save}
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
                                <FormControl fullWidth disabled={isLoading}>
                                    <InputLabel id="planoId-label">Plano</InputLabel>
                                    <Select
                                        labelId="planoId-label"
                                        label="Plano"
                                        name="planoId"
                                        defaultValue=""
                                        onChange={(e) => setPlanoId(e.target.value)}  // Atualizando o estado com a seleção
                                    >
                                        {planos.map((plano) => (
                                            <MenuItem key={plano.id} value={plano.id}>
                                                {plano.nomePlano}
                                            </MenuItem>
                                        ))}
                                        
                                    </Select>
                                </FormControl>
                            </Grid>
                        </Grid>
                        <Grid container item direction="row"  spacing={2}>
                            <Grid item xs={12} sm={12} md={6} lg={4} xl={2}>
                                <FormControl fullWidth disabled={isLoading}>
                                    <InputLabel id="exercicioId-label">Treino</InputLabel>
                                    <Select
                                        labelId="exercicioId-label"
                                        label="Treino"
                                        name="exercicioId"
                                        defaultValue=""
                                        onChange={(e) => setExercicioId(e.target.value)}  // Atualizando o estado com a seleção
                                    >
                                        {exercicios.map((exercicio) => (
                                            <MenuItem key={exercicio.id} value={exercicio.id}>
                                                {exercicio.nome}
                                            </MenuItem>
                                        ))}
                                        
                                    </Select>
                                </FormControl>
                            </Grid>
                        </Grid>


                    </Grid>
                </Box>
            </Form> 

        </LayoutBaseDePagina>
    );
};
