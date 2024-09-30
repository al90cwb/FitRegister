using System;

namespace API.Models;

public class Professor : UsuarioBase
{
  public List<Aluno> Alunos { get; set; } = new List<Aluno>();

    public Professor(int id,string nome, string endereco, string telefone, string login, string senha)
        : base(id,nome, endereco, telefone, login, senha)
    {
    }

    public void CadastrarTreino(Treino treino, Aluno aluno)
    {
        aluno.Treino = treino;
        aluno.DataDuracao = DateTime.Now.AddDays(treino.DuracaoEmDias);
    }
}
