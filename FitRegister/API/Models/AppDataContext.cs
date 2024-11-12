using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext 
{
     public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) {}

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FitRegisterDb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //Relação N-1  Aluno Plano
            modelBuilder.Entity<Aluno>()
            .HasOne(a => a.Plano )
            .WithMany(p => p.Alunos )
            .HasForeignKey(a => a.PlanoId )
            .OnDelete(DeleteBehavior.Restrict);

            //Relação N-N Treino-Exercicio
            modelBuilder.Entity<Treino>()
            .HasMany(t => t.Exercicios)
            .WithMany(e => e.Treinos)
            .UsingEntity(j => j.ToTable("TreinoExercicio"));
        }
}
