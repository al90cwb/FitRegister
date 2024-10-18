using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public abstract class Usuario
{
    public string Id { get; set; }
    [Required(ErrorMessage = "O Nome do usuário é obrigatório.")]
    public string?  Nome { get; set; }
    [Required(ErrorMessage = "O Endereço do usuário é obrigatório.")]
    public string? Endereco { get; set; }
    [Required(ErrorMessage = "O Telefone do usuário é obrigatório.")]
    public string? Telefone { get; set; }
    [Required(ErrorMessage = "O E-mail do usuário é obrigatório.")]
    [EmailAddress(ErrorMessage = "O E-mail informado não é válido.")]
    public string? Login { get; set; }
    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número ou um caractere especial.")]
    public string? Senha { get; set; }
    public DateTime CriadoEm { get; set; }

    protected Usuario(string nome, string endereco, string telefone, string login, string senha)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        Login = login;
        Senha = senha;
        CriadoEm = DateTime.Now;
    }
}
