using System;

namespace API.Models;

public interface IUsuarioFactory
{
    Aluno CreateAluno(string nome, string endereco, string telefone, string login, string senha, PlanoDeUso plano, Professor professor);
    Professor CreateProfessor(string nome, string endereco, string telefone, string login, string senha);
}
