import { useEffect, useState } from "react";
import { Plano } from "../../models/Plano";
import "./PlanoListar.css";

function PlanoListar() {
  const [planos, setPlanos] = useState<Plano[]>([]);

  useEffect(() => {
    buscarPlanos();
  });

  function buscarPlanos() {
    fetch("http://localhost:5253/api/plano/listar")
      .then((resposta) => resposta.json())
      .then((planos) => {
        setPlanos(planos);
      });
  }

  return (
    <div id="listar_planos">
      <h1>Lista de Planos</h1>
      <table id="tabela_planos">
        <thead>
          <tr>
            <th>#</th>
            <th>Nome do Plano</th>
            <th>Valor</th>
            <th>Parcelas</th>
            <th>Criado Em</th>
            <th>Alunos</th>
          </tr>
        </thead>
        <tbody>
          {planos.map((plano) => (
            <tr key={plano.id}>
              <td>{plano.id}</td>
              <td>{plano.nomePlano}</td>
              <td>R$ {plano.valor.toFixed(2)}</td>
              <td>{plano.parcelas}</td>
              <td>{plano.criadoEm}</td>
              <td>
              {plano.alunos && plano.alunos.length > 0 ? (
                  <ul>
                    {plano.alunos.map((aluno) => (
                      <li key={aluno.id}>{aluno.nome}({aluno.email})</li> 
                    ))}
                  </ul>
                ) : (
                  "Sem alunos" 
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default PlanoListar;
