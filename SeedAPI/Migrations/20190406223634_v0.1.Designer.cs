﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeedAPI.Models;

namespace SeedAPI.Migrations
{
    [DbContext(typeof(SeedAPIContext))]
    [Migration("20190406223634_v0.1")]
    partial class v01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeedAPI.Model.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoordenadorId");

                    b.Property<string>("Nome");

                    b.HasKey("CursoId");

                    b.HasIndex("CoordenadorId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("SeedAPI.Model.CursoDisciplina", b =>
                {
                    b.Property<int>("CursoDisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<int?>("DisciplinaId");

                    b.HasKey("CursoDisciplinaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("CursoDisciplina");
                });

            modelBuilder.Entity("SeedAPI.Model.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoId");

                    b.Property<string>("Nome");

                    b.Property<int>("PlanoDeEnsinoId");

                    b.Property<int>("ProfessorId");

                    b.HasKey("DisciplinaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("PlanoDeEnsinoId")
                        .IsUnique();

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("SeedAPI.Model.PlanoDeAula", b =>
                {
                    b.Property<int>("PlanoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("PlanoId");

                    b.ToTable("PlanoDeAula");
                });

            modelBuilder.Entity("SeedAPI.Model.PlanoDeEnsino", b =>
                {
                    b.Property<int>("PlanoDeEnsinoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("PlanoDeEnsinoId");

                    b.ToTable("PlanoDeEnsino");
                });

            modelBuilder.Entity("SeedAPI.Model.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoDisciplinaId");

                    b.Property<int?>("PlanoDeAulaPlanoId");

                    b.Property<int?>("ProfessorUsuarioId");

                    b.HasKey("TurmaId");

                    b.HasIndex("CursoDisciplinaId");

                    b.HasIndex("PlanoDeAulaPlanoId");

                    b.HasIndex("ProfessorUsuarioId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("SeedAPI.Model.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<int>("Privilegio");

                    b.Property<string>("Senha");

                    b.Property<string>("Titulacao");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SeedAPI.Model.Curso", b =>
                {
                    b.HasOne("SeedAPI.Model.Usuario", "Coordenador")
                        .WithMany()
                        .HasForeignKey("CoordenadorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeedAPI.Model.CursoDisciplina", b =>
                {
                    b.HasOne("SeedAPI.Model.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeedAPI.Model.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");
                });

            modelBuilder.Entity("SeedAPI.Model.Disciplina", b =>
                {
                    b.HasOne("SeedAPI.Model.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.HasOne("SeedAPI.Model.PlanoDeEnsino", "PlanoDeEnsino")
                        .WithOne("Disciplina")
                        .HasForeignKey("SeedAPI.Model.Disciplina", "PlanoDeEnsinoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeedAPI.Model.Usuario", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeedAPI.Model.Turma", b =>
                {
                    b.HasOne("SeedAPI.Model.CursoDisciplina", "CursoDisciplina")
                        .WithMany()
                        .HasForeignKey("CursoDisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeedAPI.Model.PlanoDeAula", "PlanoDeAula")
                        .WithMany()
                        .HasForeignKey("PlanoDeAulaPlanoId");

                    b.HasOne("SeedAPI.Model.Usuario", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorUsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
