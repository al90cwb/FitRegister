using System;

namespace API.Models;

public class Professor : Usuario
{
    public List<Aluno> Alunos { get; set; } = new List<Aluno>();

    public Professor(string nome, string endereco, string telefone, string login, string senha)
        : base(nome, endereco, telefone, login, senha)
    {
    }

    internal void DefinirTreinoAluno(string dia, Treino treino, Aluno aluno)
    {
        switch (dia.ToLower())
        {
            case "segunda":
                aluno.TreinoSegunda = treino;
                break;
            case "terca":
                aluno.TreinoTerca = treino;
                break;
            case "quarta":
                aluno.TreinoQuarta = treino;
                break;
            case "quinta":
                aluno.TreinoQuinta = treino;
                break;
            case "sexta":
                aluno.TreinoSexta = treino;
                break;
            case "sabado":
                aluno.TreinoSabado = treino;
                break;
            case "domingo":
                aluno.TreinoDomingo = treino;
                break;
            default:
                throw new ArgumentException("Dia da semana inválido. Utilize 'segunda', 'terca', 'quarta', 'quinta', 'sexta', 'sabado' ou 'domingo'.");
        }
    }

    public void CadastrarPlanoAluno(Plano plano, Aluno aluno)
    {
        aluno.Plano = plano;
        plano.Alunos.Add(aluno);
    }

}
