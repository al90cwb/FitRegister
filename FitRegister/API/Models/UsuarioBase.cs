using System;

namespace API.Models;

public abstract class UsuarioBase
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    protected UsuarioBase(int id,string nome, string endereco, string telefone, string login, string senha)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        Login = login;
        Senha = senha;
    }
}
