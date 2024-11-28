import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Box, Button, TextField, Typography, Paper } from "@mui/material";
import { AlunosService } from "../../shared/services/api/alunos/AlunosService";
import { ProfessoresService } from "../../shared/services/api/professores/ProfessoresService";

export const Login: React.FC = () => {
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [erro, setErro] = useState("");
    const navigate = useNavigate();

    const handleLogin = () => {
        setErro("");
    
        AlunosService.login({ email, senha }).then((result) => {
            console.log(result); 
            if (!(result instanceof Error)) {
                if (result.role === "Aluno") {
                    navigate(`/alunos/visualizar/${result .id!}`);
                } else if (result.role === "Professor") {
                    navigate(`/professores/visualizar/${result.id}`);  
                }
            } else {
                setErro("Login inválido! Verifique suas credenciais.");
            }
        });
    };

    return (
        <Box
            display="flex"
            alignItems="center"
            justifyContent="center"
            height="100vh"
        >
            <Paper elevation={3} style={{ padding: "20px", maxWidth: "400px" }}>
                <Typography variant="h5" marginBottom={2}>
                    Login
                </Typography>
                <TextField
                    label="Email"
                    fullWidth
                    margin="normal"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <TextField
                    label="Senha"
                    fullWidth
                    type="password"
                    margin="normal"
                    value={senha}
                    onChange={(e) => setSenha(e.target.value)}
                />
                {erro && (
                    <Typography color="error" variant="body2">
                        {erro}
                    </Typography>
                )}
                <Box marginTop={2} display="flex" justifyContent="flex-end">
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleLogin}
                    >
                        Entrar
                    </Button>
                </Box>
            </Paper>
        </Box>
    );
};
