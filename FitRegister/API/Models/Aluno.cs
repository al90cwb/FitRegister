using System;

namespace API.Models;

public class Aluno : UsuarioBase
{
    public Treino Treino { get; set; }
    public DateTime DataDuracao { get; set; }
    public PlanoDeUso Plano { get; set; }
    public Professor Professor { get; set; } // Agora o Aluno possui um Professor

    public Aluno(int id,string nome, string endereco, string telefone, string login, string senha, PlanoDeUso plano, Professor professor)
        : base(id,nome, endereco, telefone, login, senha)
    {
        Plano = plano;
        Professor = professor;
        Professor.Alunos.Add(this); // Adiciona o aluno à lista de alunos do professor
    }
}
