import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Box, Card, CardContent, Grid, LinearProgress, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { ProfessoresService } from "../../shared/services/api/professores/ProfessoresService";
import { ExerciciosService } from "../../shared/services/api/treinos/TreinosService";

export const VisualizarProfessor: React.FC = () => {
    const { id } = useParams<'id'>();
    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState(false);
    const [professor, setProfessor] = useState<any | null>(null);
    const [exercicio, setExercicio] = useState<any | null>(null);

    useEffect(() => {
        if (id) {
            setIsLoading(true);
            ProfessoresService.getById(id)
                .then((result) => {
                    setIsLoading(false);
                    if (result instanceof Error) {
                        alert(result.message);
                        navigate('/professores');
                    } else {
                        setProfessor(result);
    
                        if (result.exercicioId) {
                            ExerciciosService.getById(result.exercicioId)
                                .then((exercicioResult) => {
                                    if (exercicioResult instanceof Error) {
                                        console.error(exercicioResult.message);
                                        alert(exercicioResult.message);
                                    } else {
                                        setExercicio(exercicioResult);
                                    }
                                });
                        }
                    }
                })
        }
    }, [id]);
    

    if (isLoading) {
        return <LinearProgress variant="indeterminate" />;
    }

    if (!professor) {
        return <Typography variant="h6">Professor não encontrado</Typography>;
    }

    return (
        <LayoutBaseDePagina 
            titulo={`Professor: ${professor.nome}`}
            barraDeFerramentas={
                <FerramentasDeDetalhe
                    mostarBotaoSalvar = {false}
                    mostarBotaoNovo = {false}
                    mostarBotaoApagar = {false}
                    aoClicarEmVoltar={() => navigate('/professores')}
                />
            }
        >
            <Box margin={2} component={Paper} variant="outlined" padding={2}>
                <Typography variant="h6">Informações do Professor</Typography>
                <Grid container spacing={2} marginTop={2}>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Nome:</strong> {professor.nome}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Email:</strong> {professor.email}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Telefone:</strong> {professor.telefone}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Endereço:</strong> {professor.endereco}</Typography>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Typography><strong>Data de Cadastro:</strong> {new Date(professor.criadoEm).toLocaleDateString()}</Typography>
                    </Grid>
                </Grid>

                {exercicio && (
                    <Card variant="outlined" sx={{ marginBottom: 3, border: "2px solid #ff9800" }}>
                        <CardContent>
                            <Typography variant="h6" gutterBottom sx={{ color: "#ff9800" }}>Exercício</Typography>
                            <TableContainer component={Paper}>
                                <Table sx={{ minWidth: 650 }} aria-label="tabela de exercício do aluno">
                                    <TableHead>
                                        <TableRow>
                                            <TableCell sx={{ fontWeight: 'bold', backgroundColor: '#f0f0f0' }}>Campo</TableCell>
                                            <TableCell sx={{ fontWeight: 'bold', backgroundColor: '#f0f0f0' }}>Detalhes</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        <TableRow>
                                            <TableCell><strong>Exercício ID:</strong></TableCell>
                                            <TableCell>{professor.exercicioId}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Nome do Exercício:</strong></TableCell>
                                            <TableCell>{exercicio.nome}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Descrição:</strong></TableCell>
                                            <TableCell>{exercicio.descricao}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Grupo Muscular:</strong></TableCell>
                                            <TableCell>{exercicio.grupoMuscular}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Repetições:</strong></TableCell>
                                            <TableCell>{exercicio.repeticoes}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Tempo de Descanso:</strong></TableCell>
                                            <TableCell>{exercicio.tempoDescanco}</TableCell>
                                        </TableRow>
                                    </TableBody>
                                </Table>
                            </TableContainer>
                        </CardContent>
                    </Card>
                )}
            </Box>
        </LayoutBaseDePagina>
    );
};
