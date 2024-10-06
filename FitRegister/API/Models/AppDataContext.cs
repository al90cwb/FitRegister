using System;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FitResiterDb.db");//string de conexão
    }

}
