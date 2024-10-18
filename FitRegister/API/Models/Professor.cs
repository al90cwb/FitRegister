using System;

namespace API.Models;

public class Professor : Usuario
{
    public List<Aluno>? Alunos { get; set; } 

    public Professor(string nome, string endereco, string telefone, string email, string senha)
        : base(nome, endereco, telefone, email, senha)
    {
        Alunos = new List<Aluno>();
    }
}
