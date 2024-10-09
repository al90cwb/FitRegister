using System;

namespace API.Models;

public class ProfessorUpdateDTO
{
    public string Id { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; } 
    public string? Telefone { get; set; }
    public string? Login { get; set; } 
    public string? Senha { get; set; } 
}
