using System;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Treino> Treinos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FitResiterDb.db");//string de conexão
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Plano)
                .WithMany(p => p.Alunos)
                .HasForeignKey("PlanoId");
                
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Professor)
                .WithMany(p => p.Alunos)
                .HasForeignKey("ProfessorId");
                
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Treino)
                .WithMany(t => t.Alunos)
                .HasForeignKey("TreinoId");
        }


}
