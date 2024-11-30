import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Box, LinearProgress, Paper, Typography, Card, CardContent, Divider, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { AlunosService } from "../../shared/services/api/alunos/AlunosService";
import { PlanosService } from "../../shared/services/api/planos/PlanosService";
import { ExerciciosService } from "../../shared/services/api/treinos/TreinosService";

export const VisualizarAluno: React.FC = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [plano, setPlano] = useState<any | null>(null);
    const [isLoading, setIsLoading] = useState(false);
    const [aluno, setAluno] = useState<any | null>(null);
    const [exercicio, setExercicio] = useState<any | null>(null);
    const userRole = localStorage.getItem("userRole");

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
    
                        if (result.planoId){
                            PlanosService.getById(result.planoId)
                            .then((result) => {
                                if (result instanceof Error) {
                                    alert(result.message);
                                    navigate('/alunos');
                                } else {
                                    setPlano(result);
                                }
                            });
                        }
                       
    
                        if (result.exercicioId) {
                            ExerciciosService.getById(result.exercicioId)
                                .then((result) => {
                                    if (result instanceof Error) {
                                        alert(result.message);
                                        navigate('/alunos');
                                    } else {
                                        setExercicio(result);
                                    }
                                });
                        }
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
        <LayoutBaseDePagina  titulo={`Aluno: ${aluno.nome}`} >
             {userRole === "Professor" && (
                <FerramentasDeDetalhe aoClicarEmVoltar={() => navigate('/alunos')} />
            )}

            <Box margin={2}>
                <Typography variant="h4" gutterBottom>Informações do Aluno</Typography>

                {/* Dados Pessoais */}
                <Card variant="outlined" sx={{ marginBottom: 3, border: "2px solid #1976d2" }}>
                    <CardContent>
                        <Typography variant="h6" gutterBottom sx={{ color: "#1976d2" }}>Dados Pessoais</Typography>
                        <TableContainer component={Paper}>
                            <Table sx={{ minWidth: 650 }} aria-label="tabela de dados pessoais">
                                <TableHead>
                                    <TableRow>
                                        <TableCell sx={{ fontWeight: 'bold', backgroundColor: '#f0f0f0' }}>Campo</TableCell>
                                        <TableCell sx={{ fontWeight: 'bold', backgroundColor: '#f0f0f0' }}>Detalhes</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    <TableRow>
                                        <TableCell><strong>Nome:</strong></TableCell>
                                        <TableCell>{aluno.nome}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell><strong>Email:</strong></TableCell>
                                        <TableCell>{aluno.email}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell><strong>Telefone:</strong></TableCell>
                                        <TableCell>{aluno.telefone}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell><strong>Endereço:</strong></TableCell>
                                        <TableCell>{aluno.endereco}</TableCell>
                                    </TableRow>
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </CardContent>
                </Card>


                

                {/* Plano do Aluno */}
                {plano && (
                    <Card variant="outlined" sx={{ marginBottom: 3, border: "2px solid #4caf50" }}>
                        <CardContent>
                            <Typography variant="h6" gutterBottom sx={{ color: "#4caf50" }}>Plano</Typography>
                            <TableContainer component={Paper}>
                                <Table sx={{ minWidth: 650 }} aria-label="tabela de plano do aluno">
                                    <TableHead>
                                        <TableRow>
                                            <TableCell sx={{ fontWeight: 'bold', backgroundColor: '#f0f0f0' }}>Campo</TableCell>
                                            <TableCell sx={{ fontWeight: 'bold', backgroundColor: '#f0f0f0' }}>Detalhes</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        <TableRow>
                                            <TableCell><strong>Plano ID:</strong></TableCell>
                                            <TableCell>{aluno.planoId}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Nome do Plano:</strong></TableCell>
                                            <TableCell>{plano.nomePlano}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Parcelas:</strong></TableCell>
                                            <TableCell>{plano.parcelas}</TableCell>
                                        </TableRow>
                                        <TableRow>
                                            <TableCell><strong>Valor:</strong></TableCell>
                                            <TableCell>{plano.valor}</TableCell>
                                        </TableRow>
                                    </TableBody>
                                </Table>
                            </TableContainer>
                        </CardContent>
                    </Card>
                )}

                {/* Exercício do Aluno */}
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
                                            <TableCell>{aluno.exercicioId}</TableCell>
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
                                    </TableBody>
                                </Table>
                            </TableContainer>
                        </CardContent>
                    </Card>
                )}

                {/* Data de Cadastro */}
                <Card variant="outlined">
                    <CardContent>
                        <Typography variant="h6" gutterBottom>Cadastro</Typography>
                        <Typography><strong>Data de Cadastro:</strong> {new Date(aluno.criadoEm).toLocaleDateString()}</Typography>
                    </CardContent>
                </Card>
            </Box>
        </LayoutBaseDePagina>
    );
};
