import { useEffect, useState } from "react";
import { Aluno } from "../../models/Aluno";
import "./AlunoListar.css";

function AlunoListar(){
    const [alunos, setAlunos] = useState<Aluno[]>([]);

    useEffect(() =>{
        buscarAluno();
    });


function buscarAluno(){
    fetch("http://localhost:5253/api/aluno/listar")
        .then((resposta) => resposta.json())
        .then((alunos) => {
            setAlunos(alunos);
        });
}

return(
    <div id="listar_alunos">
        <h1>Lista de Alunos</h1>
        <table id="tabela"> 
            <thead>
                <tr>
                    <th>#</th>
                    <th>Nome</th>
                    <th>Endereço</th>
                    <th>Telefone</th>
                    <th>Email</th>
                    <th>Criado Em</th>
                    <th>Plano ID</th>
                </tr>
            </thead>
            <tbody>
                {alunos.map((aluno) => (
                    <tr>
                        <td>{aluno.id}</td>
                        <td>{aluno.nome}</td>
                        <td>{aluno.endereco}</td>
                        <td>{aluno.telefone}</td>
                        <td>{aluno.email}</td>
                        <td>{aluno.criadoEm}</td>
                        <td>{aluno.planoId}</td>
                    </tr>
                ))}
            </tbody>

        </table>
    </div>
    );
}


export default AlunoListar