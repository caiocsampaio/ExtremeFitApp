﻿// <auto-generated />
using System;
using ExtremeFit.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace ExtremeFit.Repository.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExtremeFit.Domain.Entities.AlternativaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("PerguntaId");

                    b.HasKey("Id");

                    b.HasIndex("PerguntaId");

                    b.ToTable("Alternativas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.AtletaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Esporte")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.DadosFuncionarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("DadosFuncionarios");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.DicaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.Property<bool>("Validacao");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Dicas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.EmpresaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNAE")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.EspecialistaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Especialistas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.EventoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("UnidadeId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.FuncionarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Altura");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Peso");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.FuncionarioUnidadeSesiDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FuncionarioId");

                    b.Property<int>("UnidadeId");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("FuncionariosUnidadesFavoritas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.IntensidadeDorDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Intensidade")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("IntensidadeDores");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.LocalDorDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocalDor")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("LocalDores");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.PerguntaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.PermissaoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomePermissao")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.PesquisaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlternativaId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Pergunta");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AlternativaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Pesquisas");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.RelatorioDorDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("EmpresaId");

                    b.Property<int>("IntensidadeDorId");

                    b.Property<int>("LocalDorId");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("IntensidadeDorId");

                    b.HasIndex("LocalDorId");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.UnidadeSesiDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("NomeUnidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("UnidadesSesi");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.UsuarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<string>("Digital");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Rfid");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.UsuarioPermissaoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PermissaoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("PermissaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosPermissoes");
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.AlternativaDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.PerguntaDomain", "Pergunta")
                        .WithMany("Alternativas")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.DadosFuncionarioDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.EmpresaDomain", "Empresa")
                        .WithMany("DadosFuncionarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.DicaDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.UsuarioDomain", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.EspecialistaDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.UsuarioDomain", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.EventoDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.UnidadeSesiDomain", "Unidade")
                        .WithMany("Eventos")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExtremeFit.Domain.Entities.UsuarioDomain", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.FuncionarioDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.UsuarioDomain", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.FuncionarioUnidadeSesiDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.FuncionarioDomain", "Funcionario")
                        .WithMany("UnidadesFavoritas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExtremeFit.Domain.Entities.UnidadeSesiDomain", "Unidade")
                        .WithMany("Funcionarios")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.PesquisaDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.AlternativaDomain", "Alternativa")
                        .WithMany("Pesquisas")
                        .HasForeignKey("AlternativaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExtremeFit.Domain.Entities.EmpresaDomain", "Empresa")
                        .WithMany("Pesquisas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.RelatorioDorDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.EmpresaDomain", "Empresa")
                        .WithMany("Relatorios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExtremeFit.Domain.Entities.IntensidadeDorDomain", "Intensidade")
                        .WithMany()
                        .HasForeignKey("IntensidadeDorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExtremeFit.Domain.Entities.LocalDorDomain", "LocalDor")
                        .WithMany()
                        .HasForeignKey("LocalDorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExtremeFit.Domain.Entities.UsuarioPermissaoDomain", b =>
                {
                    b.HasOne("ExtremeFit.Domain.Entities.PermissaoDomain", "Permissao")
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExtremeFit.Domain.Entities.UsuarioDomain", "Usuario")
                        .WithMany("Permissoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
