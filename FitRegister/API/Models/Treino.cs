using System;

namespace API.Models;

public class Treino
{
    public string? Id { get; set; }
    public string Descricao { get; set; }
    public int DuracaoEmDias { get; set; }
    public List<Aluno>? Alunos { get; set; } 

    public Treino( string descricao, int duracaoEmDias)
    {
        Id = Guid.NewGuid().ToString();
        Descricao = descricao;
        DuracaoEmDias = duracaoEmDias;
        Alunos = new List<Aluno>();
    }
}
