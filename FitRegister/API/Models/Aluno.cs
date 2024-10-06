using System;

namespace API.Models;

public class Aluno : Usuario
{
    public Treino? TreinoSegunda { get; set; }
    public Treino?  TreinoTerca { get; set; }
    public Treino?  TreinoQuarta { get; set; }
    public Treino?  TreinoQuinta { get; set; }
    public Treino?  TreinoSexta { get; set; }
    public Treino?  TreinoSabado { get; set; }
    public Treino?  TreinoDomingo { get; set; }
    public DateTime?  DataDuracao { get; set; }
    public PlanoDeUso?  Plano { get; set; }
    public Professor?  Professor { get; set; } // Agora o Aluno possui um Professor

    public Aluno(string nome, string endereco, string telefone, string login, string senha)
        : base(nome, endereco, telefone, login, senha)
    {
    }

    public void SetPlanoDeUso(PlanoDeUso plano)
    {
        this.Plano = plano;
    }

    public void SetProfessor(Professor professor)
    {
        Professor = professor;
        Professor.Alunos.Add(this); // Adiciona o aluno à lista de alunos do professor
    }

    public void RemoveProfessor()
    {
        if (Professor != null)
        {
            Professor.Alunos.Remove(this);

            Professor = null;
        }
    }

    public Treino ObterTreino(string dia)
    {
        return dia.ToLower() switch
        {
            "segunda" => TreinoSegunda,
            "terca" => TreinoTerca,
            "quarta" => TreinoQuarta,
            "quinta" => TreinoQuinta,
            "sexta" => TreinoSexta,
            "sabado" => TreinoSabado,
            "domingo" => TreinoDomingo,
            _ => throw new ArgumentException("Dia da semana inválido. Utilize 'segunda', 'terca', 'quarta', 'quinta', 'sexta', 'sabado' ou 'domingo'."),
        };
    }

}
