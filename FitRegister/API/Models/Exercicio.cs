using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

public class Exercicio
{

    public Guid? Id { get; set; }
    //[Required(ErrorMessage = "E necessário escolher um nome para o exercicio.")]
    public string? Nome { get; set; }
    //[Required(ErrorMessage = "E necessário escolher um grupo para o exercicio.")]
    public string? GrupoMuscular { get; set; }
    //[Required(ErrorMessage = "E necessário escolher uma descrição para o exercicio.")]
    public string? Descricao { get; set; }
    //[Required(ErrorMessage = "E necessário escolher a quantidade de repetições para o exercicio.")]
    public int? Repeticoes { get; set; }
    //[Required(ErrorMessage = "E necessário definir o tempo de descanço para o exercicio.")]
    public int? TempoDescanso { get; set; }
    public DateTime? CriadoEm { get; set; }
    public Exercicio()
    {
        CriadoEm = DateTime.Now;
    }
}
