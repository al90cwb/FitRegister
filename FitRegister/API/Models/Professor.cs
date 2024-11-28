using System;

namespace API.Models;

public class Professor : Usuario
{
    public List<Aluno>? Alunos { get; set; } 

    public Exercicio? Exercicio { get; set; }
    public Guid? ExercicioId { get; set; }

    public Professor(string nome, string endereco, string telefone, string email, string senha, Guid? exercicioId)
        : base(nome, endereco, telefone, email, senha)
    {
        ExercicioId = exercicioId;
        Alunos = new List<Aluno>();
    }


}
