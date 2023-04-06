﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.Data;

#nullable disable

namespace ProjetoFinal.Migrations
{
    [DbContext(typeof(ProjetoFinalContext))]
    partial class ProjetoFinalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFinal.Models.Avaliacoes.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoId"), 1L, 1);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Disciplinas.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplinaId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("DisciplinaId");

                    b.HasIndex("SerieId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Materias.Materia", b =>
                {
                    b.Property<int>("MateriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MateriaId"), 1L, 1);

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MateriaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Notificacoes.Mensagem", b =>
                {
                    b.Property<int>("MensagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MensagemId"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MensagemId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Notificacoes.Notificacao", b =>
                {
                    b.Property<int>("NotificacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificacaoId"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMensagem")
                        .HasColumnType("int");

                    b.Property<int>("MensagemId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("NotificacaoId");

                    b.HasIndex("MensagemId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notificacao");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Series.Serie", b =>
                {
                    b.Property<int>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SerieId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerieId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Turmas.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurmaId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("TurmaId");

                    b.HasIndex("SerieId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoId"), 1L, 1);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessorId"), 1L, 1);

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<int>("Atividade")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Avaliacoes.Avaliacao", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Usuarios.Aluno", null)
                        .WithMany("Avaliacoes")
                        .HasForeignKey("AlunoId");

                    b.HasOne("ProjetoFinal.Models.Materias.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Disciplinas.Disciplina", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Series.Serie", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("SerieId");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Materias.Materia", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Disciplinas.Disciplina", null)
                        .WithMany("Materias")
                        .HasForeignKey("DisciplinaId");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Notificacoes.Notificacao", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Notificacoes.Mensagem", "Mensagem")
                        .WithMany()
                        .HasForeignKey("MensagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Usuarios.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mensagem");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Turmas.Turma", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Series.Serie", null)
                        .WithMany("Turmas")
                        .HasForeignKey("SerieId");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Administrador", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Usuarios.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Aluno", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Usuarios.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Turmas.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Professor", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Disciplinas.Disciplina", "Disciplina")
                        .WithMany("Professores")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Usuarios.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Usuario", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Usuarios.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Disciplinas.Disciplina", b =>
                {
                    b.Navigation("Materias");

                    b.Navigation("Professores");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Series.Serie", b =>
                {
                    b.Navigation("Disciplinas");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Turmas.Turma", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuarios.Aluno", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
