using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Aluno : Usuario
{
    public Treino? Treino { get; set; }
    public Plano?  Plano { get; set; }
    public Professor?  Professor { get; set; } 

    public Aluno(string nome, string endereco, string telefone, string login, string senha)
        : base(nome, endereco, telefone, login, senha)
    {
    }

}
