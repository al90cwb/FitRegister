using System;

namespace API.Models;

public class Plano
{
    public string? Id { get; set; }
    public string NomePlano { get; set; }
    public decimal Valor { get; set; }
    public List<Aluno>? Alunos { get; set; } 

    public Plano( string nomePlano, decimal valor)
    {
        Id = Guid.NewGuid().ToString();
        NomePlano = nomePlano;
        Valor = valor;
        Alunos = new List<Aluno>();
    }
}
