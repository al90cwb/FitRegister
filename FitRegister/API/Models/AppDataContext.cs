using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext 
{
     public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) {}

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FitRegisterDb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
        }
}
