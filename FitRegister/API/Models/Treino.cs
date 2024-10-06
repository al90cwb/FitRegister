using System;

namespace API.Models;

public class Treino
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int DuracaoEmDias { get; set; } // Duração do treino

    public Treino(int id, string descricao, int duracaoEmDias)
    {
        Id = id;
        Descricao = descricao;
        DuracaoEmDias = duracaoEmDias;
    }
}
