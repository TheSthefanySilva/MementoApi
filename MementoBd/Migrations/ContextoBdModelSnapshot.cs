﻿// <auto-generated />
using System;
using MementoBd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MementoBd.Migrations
{
    [DbContext(typeof(ContextoBd))]
    partial class ContextoBdModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MementoBd.Entidades.CategoriaEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("Inativo")
                        .HasColumnType("bit")
                        .HasColumnName("Inativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("Nome");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("Int")
                        .HasColumnName("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("MementoBd.Entidades.ListaEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("Inativo")
                        .HasColumnType("bit")
                        .HasColumnName("Inativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("Nome");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("Int")
                        .HasColumnName("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Lista", (string)null);
                });

            modelBuilder.Entity("MementoBd.Entidades.TarefaEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("AtualizadoEm");

                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("Int")
                        .HasColumnName("UsuarioId");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("CriadoEm");

                    b.Property<DateTime>("DataLimite")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataLimite");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("Inativo")
                        .HasColumnType("bit")
                        .HasColumnName("Inativo");

                    b.Property<int>("ListaId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("Int")
                        .HasColumnName("UsuarioId");

                    b.Property<int>("Prioridade")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("Int")
                        .HasColumnName("UsuarioId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("Nome");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ListaId");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("MementoBd.Entidades.UsuarioEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("Datetime")
                        .HasColumnName("CriadoEm");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar(200)")
                        .HasColumnName("Email");

                    b.Property<bool>("Inativo")
                        .HasColumnType("bit")
                        .HasColumnName("Inativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("MementoBd.Entidades.CategoriaEntidade", b =>
                {
                    b.HasOne("MementoBd.Entidades.UsuarioEntidade", "Usuario")
                        .WithMany("Categorias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MementoBd.Entidades.ListaEntidade", b =>
                {
                    b.HasOne("MementoBd.Entidades.UsuarioEntidade", "Usuario")
                        .WithMany("Listas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MementoBd.Entidades.TarefaEntidade", b =>
                {
                    b.HasOne("MementoBd.Entidades.CategoriaEntidade", "Categoria")
                        .WithMany("Tarefas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MementoBd.Entidades.ListaEntidade", "Lista")
                        .WithMany("Tarefas")
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Lista");
                });

            modelBuilder.Entity("MementoBd.Entidades.CategoriaEntidade", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("MementoBd.Entidades.ListaEntidade", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("MementoBd.Entidades.UsuarioEntidade", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Listas");
                });
#pragma warning restore 612, 618
        }
    }
}
