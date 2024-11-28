using System.Text.Json.Serialization;

namespace API.Models;

public class Aluno : Usuario
{
    public Plano? Plano { get; set; }
    public Guid PlanoId { get; set; }
    public Exercicio? Exercicio { get; set; }
    public Guid? ExercicioId { get; set; }

    public Aluno(string nome, string endereco, string telefone, string email, string senha, Guid planoId, Guid? exercicioId)
        : base(nome, endereco, telefone, email, senha)
    {
        ExercicioId = exercicioId;
        PlanoId = planoId;
    }



}
