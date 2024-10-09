using System;

namespace API.Models;

public class Plano
{
    public int Id { get; set; }
    public string? NomePlano { get; set; }
    public decimal? Valor { get; set; }
    public List<Aluno> Alunos { get; set; } = new List<Aluno>();

    public Plano() { }
    public Plano(int id, string nomePlano, decimal valor)
    {
        Id = id;
        NomePlano = nomePlano;
        Valor = valor;
    }
}
