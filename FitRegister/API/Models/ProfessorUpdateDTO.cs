using System;

namespace API.Models;

public class ProfessorUpdateDTO
{
    public string Id { get; set; }
    public string? Nome { get; set; }  // Nome pode ser null
    public string? Endereco { get; set; }  // Endereco pode ser null
    public string? Telefone { get; set; }  // Telefone pode ser null
    public string? Login { get; set; }  // Login pode ser null
    public string? Senha { get; set; }  // Senha pode ser null
}
