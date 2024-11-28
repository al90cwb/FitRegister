import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Box, Grid, LinearProgress, Paper, Typography } from "@mui/material";
import { FerramentasDeDetalhe } from "../../shared/components";
import { LayoutBaseDePagina } from "../../shared/layouts";
import { ProfessoresService } from "../../shared/services/api/professores/ProfessoresService";

export const VisualizarProfessor: React.FC = () => {
    const { id } = useParams<'id'>();
    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState(false);
    const [professor, setProfessor] = useState<any | null>(null);

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
                    }
                });
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
            </Box>
        </LayoutBaseDePagina>
    );
};
