using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Treino
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O Nome do treino é obrigatório.")]
    public string? Nome { get; set; }
    public string? Finalidade { get; set; }
    public string? Descricao { get; set; }
    public string? NivelTreino  { get; set; }
    public ICollection<Exercicio> Exercicios { get; set; } = new List<Exercicio>(); 
    public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    public DateTime CriadoEm { get; set; }
    
    public Treino()
    {
        CriadoEm = DateTime.Now;
    }
}
