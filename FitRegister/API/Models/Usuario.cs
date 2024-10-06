using System;

namespace API.Models;

public abstract class Usuario
{
    public String Id { get; set; }
    public string  Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
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
