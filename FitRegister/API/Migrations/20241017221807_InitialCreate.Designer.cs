﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20241017221807_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlanoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TreinoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlanoId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TreinoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API.Models.Exercicio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GrupoMuscular")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Repeticoes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TempoDescanso")
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

                    b.Property<int?>("Parcelas")
                        .IsRequired()
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
                        .IsRequired()
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

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("API.Models.Treino", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Finalidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelTreino")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Treinos");
                });

            modelBuilder.Entity("ExercicioTreino", b =>
                {
                    b.Property<Guid>("ExerciciosId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TreinosId")
                        .HasColumnType("TEXT");

                    b.HasKey("ExerciciosId", "TreinosId");

                    b.HasIndex("TreinosId");

                    b.ToTable("ExercicioTreino");
                });

            modelBuilder.Entity("API.Models.Aluno", b =>
                {
                    b.HasOne("API.Models.Plano", "Plano")
                        .WithMany("Alunos")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Professor", null)
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId");

                    b.HasOne("API.Models.Treino", null)
                        .WithMany("Alunos")
                        .HasForeignKey("TreinoId");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("ExercicioTreino", b =>
                {
                    b.HasOne("API.Models.Exercicio", null)
                        .WithMany()
                        .HasForeignKey("ExerciciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Treino", null)
                        .WithMany()
                        .HasForeignKey("TreinosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Plano", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("API.Models.Treino", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}