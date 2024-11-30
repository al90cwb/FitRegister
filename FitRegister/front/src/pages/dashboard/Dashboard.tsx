import { useEffect, useState } from "react";
import { Box, Card, CardContent, Typography, Grid } from "@mui/material";

interface DashboardData {
    alunos: number;
    professores: number;
    planos: number;
    exercicios: number;
  }

export const Dashboard = () => {
    const [data, setData] = useState<DashboardData>({
        alunos: 0,
        professores: 0,
        planos: 0,
        exercicios: 0,
      });
    
    const [loading, setLoading] = useState(true);

    const fetchData = async () => {
        try {
          const response = await fetch("http://localhost:5253/api/dashboard"); // Ajuste para o seu endpoint
          const result = await response.json();
          setData(result);
        } catch (error) {
          console.error("Erro ao buscar dados do dashboard:", error);
        } finally {
          setLoading(false);
        }
      };

    useEffect(() => {
      fetchData();
    }, []);
    
    if (loading) {
      return <Typography>Carregando...</Typography>;
    }

    return (
        <Box sx={{ padding: 4 }}>
          <Typography variant="h4" gutterBottom>
            Página Inicial
          </Typography>
          <Grid container spacing={4}>
            <Grid item xs={12} sm={6} md={3}>
              <Card>
                <CardContent>
                  <Typography variant="h5">Alunos</Typography>
                  <Typography variant="h4">{data.alunos}</Typography>
                </CardContent>
              </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={3}>
              <Card>
                <CardContent>
                  <Typography variant="h5">Professores</Typography>
                  <Typography variant="h4">{data.professores}</Typography>
                </CardContent>
              </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={3}>
              <Card>
                <CardContent>
                  <Typography variant="h5">Planos</Typography>
                  <Typography variant="h4">{data.planos}</Typography>
                </CardContent>
              </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={3}>
              <Card>
                <CardContent>
                  <Typography variant="h5">Exercícios</Typography>
                  <Typography variant="h4">{data.exercicios}</Typography>
                </CardContent>
              </Card>
            </Grid>
          </Grid>
        </Box>
      );
};