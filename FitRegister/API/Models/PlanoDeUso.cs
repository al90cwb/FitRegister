using System;

namespace API.Models;

public class PlanoDeUso
{
    public int Id { get; set; }
    public string NomePlano { get; set; }
    public decimal Valor { get; set; }

    public PlanoDeUso(int id,string nomePlano, decimal valor)
    {
        Id = id;
        NomePlano = nomePlano;
        Valor = valor;
    }
}
