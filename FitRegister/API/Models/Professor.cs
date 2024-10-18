using System;

namespace API.Models;

public class Professor : Usuario
{
    public List<Aluno>? Alunos { get; set; } 

    public Professor(string nome, string endereco, string telefone, string login, string senha)
        : base(nome, endereco, telefone, login, senha)
    {
        Alunos = new List<Aluno>();
    }

}
