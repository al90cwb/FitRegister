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
    public int Parcelas { get; set; }
    public DateTime CriadoEm { get; set; }
    // Construtor sem parâmetros
    public Plano()
    {
        CriadoEm = DateTime.Now;
    }
    
}
