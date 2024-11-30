import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Box, Button, TextField, Typography, Paper, Avatar, Grid } from "@mui/material";
import { logo192 } from "../../shared/images"; 
import { AlunosService, IDetalheAluno, IListagemAlunos } from "../../shared/services/api/alunos/AlunosService";
import { useVForm, VTextField } from "../../shared/forms";
import { Form } from "@unform/web";

export const Cadastrar: React.FC = () => {
    const [nome, setNome] = useState("");
    const [telefone, setTelefone] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [erro, setErro] = useState("");
    const navigate = useNavigate();

    

    const handleVoltar = () => {
        navigate('/login');
        console.log("Voltando");
    }





    const handleCadastrar = () => {
        console.log("Cadastrado");
    
        // Objeto contendo os dados do aluno
        const dados : Omit<IDetalheAluno, 'id' | 'planoId' | 'exercicioId' > = {
            nome: nome,
            telefone: telefone,
            email: email,
            senha : senha,
        };

        console.log(dados);
    
        // Envia os dados para o serviço
        AlunosService.create(dados)
            .then((result) => {
                if (result instanceof Error) {
                    setErro(result.message); // Mostra a mensagem de erro
                } else {
                    alert("Aluno cadastrado com sucesso!");
                    navigate('/login'); // Redireciona para a tela de login
                }
            })
            .catch((error) => {
                setErro("Erro ao cadastrar aluno."); // Trata erros inesperados
                console.error(error);
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
                <Box display="flex" justifyContent="center" marginBottom={2}>
                    <Avatar alt="Logo" src={logo192} sx={{ width: 300, height: 200 }} />
                </Box>

                <Typography variant="h5" marginBottom={2}  >
                    Cadastrar
                </Typography>


                <TextField
                    label="Nome"
                    fullWidth
                    margin="normal"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                />

                <TextField
                    label="Telefone"
                    fullWidth
                    margin="normal"
                    value={telefone}
                    onChange={(e) => setTelefone(e.target.value)}
                />

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
                            <Box  margin={1}>
                                <Button
                                    variant="contained"
                                    color="primary"
                                    onClick={handleVoltar}
                                >
                                    Voltar
                                </Button>
                            </Box>
                        
                            <Box  margin={1}>
                                <Button
                                    variant="contained"
                                    color="primary"
                                    onClick={handleCadastrar}
                                >
                                    Cadastrar
                                </Button>
                            </Box>

                        </Box>
            </Paper>
            
        </Box>
    );
};
