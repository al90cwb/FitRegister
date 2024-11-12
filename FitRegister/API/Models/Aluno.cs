using System.Text.Json.Serialization;

namespace API.Models;

public class Aluno : Usuario
{
    [JsonIgnore]
    public Plano? Plano { get; set; }
    public Guid PlanoId { get; set; }

    public Aluno(string nome, string endereco, string telefone, string email, string senha,Guid planoId)
        : base(nome, endereco, telefone, email, senha)
    {
        PlanoId = planoId;
    }
}
