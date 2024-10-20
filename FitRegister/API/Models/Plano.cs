using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

public class Plano
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O Nome do plano é obrigatório.")]
    public string NomePlano { get; set; }
    [Required(ErrorMessage = "O Valor do plano é obrigatório.")]
    public decimal Valor { get; set; }
    [Required(ErrorMessage = "A quantidade de parcelas é obrigatório.")]
    public int? Parcelas { get; set; }
    [JsonIgnore]
    public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    public DateTime CriadoEm { get; set; }

    // Construtor sem parâmetros
    public Plano()
    {
        CriadoEm = DateTime.Now;
    }
    
    public Plano(string nomePlano, decimal valor, int parcelas)
    {
        NomePlano = nomePlano;
        Valor = valor;
        Parcelas = parcelas;
        CriadoEm = DateTime.Now;
    }
}
