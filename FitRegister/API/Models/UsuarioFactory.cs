using System;

namespace API.Models;

public class UsuarioFactory : IUsuarioFactory
{
    public Aluno CreateAluno(string nome, string endereco, string telefone, string login, string senha, PlanoDeUso plano, Professor professor)
    {
        var aluno = new Aluno(nome, endereco, telefone, login, senha)
        {
            Plano = plano,
            Professor = professor
        };
        professor.Alunos.Add(aluno);
        return aluno;
    }

    public Professor CreateProfessor(string nome, string endereco, string telefone, string login, string senha)
    {
        return new Professor(nome, endereco, telefone, login, senha);
    }
}
