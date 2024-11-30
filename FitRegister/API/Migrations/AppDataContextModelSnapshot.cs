﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("API.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ExercicioId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PlanoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExercicioId");

                    b.HasIndex("PlanoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API.Models.Exercicio", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("GrupoMuscular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Repeticoes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TempoDescanso")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("API.Models.Plano", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomePlano")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Parcelas")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ExercicioId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExercicioId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("API.Models.Aluno", b =>
                {
                    b.HasOne("API.Models.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId");

                    b.HasOne("API.Models.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("PlanoId");

                    b.HasOne("API.Models.Professor", null)
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Exercicio");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.HasOne("API.Models.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId");

                    b.Navigation("Exercicio");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
