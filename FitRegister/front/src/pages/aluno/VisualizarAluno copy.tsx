import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography } from "@mui/material";
import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { AlunosService, IDetalheAluno, IListagemAlunos } from "../../shared/services/api/alunos/AlunosService";
import { IDetalhePlano, PlanosService } from "../../shared/services/api/planos/PlanosService";
import { ExerciciosService } from "../../shared/services/api/exercicios/ExerciciosService";

export const VisualizarAluno: React.FC = () => {
    const { id } = useParams<'id'>();
    const navigate = useNavigate();
    const [plano, setPlano] = useState<any | null>(null);
    const [isLoading, setIsLoading] = useState(false);
    const [aluno, setAluno] = useState<any | null>(null);
    const [exercicio, setExercicio] = useState<any | null>(null);

    useEffect(() => {
        if (id) {
            setIsLoading(true);
            AlunosService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error) {
                        alert(result.message);
                        navigate('/alunos');
                    } else {
                        setAluno(result);
                        PlanosService.getById(result.planoId)
                        .then((result) => {
                            if (result instanceof Error) {
                                alert(result.message);
                                navigate('/alunos');
                            } else {
                                setPlano(result);
                            }
                        });

                        ExerciciosService.getById(result.exercicioId)
                        .then((result) => {
                            if (result instanceof Error) {
                                alert(result.message);
                                navigate('/alunos');
                            } else {
                                console.log(result);
                                setExercicio(result);
                            }
                        });

                    }
                });
        }
    }, [id]);

    if (isLoading) {
        return <LinearProgress variant="indeterminate" />;
    }

    if (!aluno) {
        return <Typography variant="h6">Aluno não encontrado</Typography>;
    }

    return (
        <LayoutBaseDePagina 
            titulo={`Aluno: ${aluno.nome}`}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    aoClicarEmVoltar={() => navigate('/alunos')}
                />
            }
        >
            <Box margin={2} component={Paper} variant="outlined" padding={2}>
                <Typography variant="h6">Informações do Aluno</Typography>
                <Grid container spacing={2} marginTop={2}>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Nome:</strong> {aluno.nome}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Email:</strong> {aluno.email}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Telefone:</strong> {aluno.telefone}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Endereço:</strong> {aluno.endereco}</Typography>
                    </Grid>
                    {plano !== null &&(
                        <Grid item xs={12} sm={6}>
                           <Grid>
                               <Typography><strong>Plano ID:</strong> {aluno.planoId}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Plano Nome:</strong> {plano.nomePlano}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Parcelas:</strong> {plano.parcelas}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Valor:</strong> {plano.valor}</Typography>
                           </Grid>
                       </Grid>
                    
                    )}

                    {exercicio !== null &&(
                        <Grid item xs={12} sm={6}>
                           <Grid>
                               <Typography><strong>Exercicio ID:</strong> {aluno.exercicioId}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Exercicio Nome:</strong> {exercicio.nome}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Descrição:</strong> {exercicio.descricao}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Grupo Musculas:</strong> {exercicio.grupoMuscular}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Repetições:</strong> {exercicio.repeticoes}</Typography>
                           </Grid>
                           <Grid>
                               <Typography><strong>Tempo Descanço:</strong> {exercicio.tempoDescanco}</Typography>
                           </Grid>
                       </Grid>
                    
                    )}

                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Data de Cadastro:</strong> {new Date(aluno.criadoEm).toLocaleDateString()}</Typography>
                    </Grid>
                </Grid>
            </Box>
        </LayoutBaseDePagina>
    );
};
