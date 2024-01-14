﻿// <auto-generated />
using System;
using FiapTechChallenge.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiapTechChallenge.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FiapTechChallenge.API.Entity.ClasseInvestimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("ClasseInvestimento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Renda Fixa"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Renda Variável"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Fundos de Investimento"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Previdência Privada"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "COE (Certificado de Operações Estruturadas)"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Operações no Mercado Internacional"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Câmbio"
                        });
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT");

                    b.Property<string>("Bairro")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CEP")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CPF")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Cidade")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Estado")
                        .HasColumnType("VARCHAR(2)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomeMae")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomePai")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NumeroConta")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Renda")
                        .HasColumnType("NUMERIC(15,2)");

                    b.HasKey("Id");

                    b.ToTable("Conta", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Bairro = "Centro",
                            CEP = "1200000",
                            CPF = "11111111111",
                            Cidade = "São Paulo",
                            Complemento = "Casa",
                            Email = "admin@admin.com",
                            Estado = "SP",
                            Logradouro = "Rua Sem Nome",
                            Nome = "Admin",
                            NomeMae = "Maria",
                            NomePai = "José",
                            Numero = "1",
                            NumeroConta = "1111",
                            Renda = 0m
                        });
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.DadosBancario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Agencia")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("CodigoBanco")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int?>("ContaId")
                        .HasColumnType("INT");

                    b.Property<int>("IdConta")
                        .HasColumnType("INT");

                    b.Property<string>("NumeroConta")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("DadosBancarios", (string)null);
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Investimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("IdClasseInvestimento")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("IdClasseInvestimento");

                    b.ToTable("Investimento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Tesouro Direto",
                            IdClasseInvestimento = 1
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "CDB (Certificado de Depósito Bancário)",
                            IdClasseInvestimento = 1
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "LCI (Letra de Crédito Imobiliário)",
                            IdClasseInvestimento = 1
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "LCA (Letra de Crédito do Agronegócio)",
                            IdClasseInvestimento = 1
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Debêntures",
                            IdClasseInvestimento = 1
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Ações",
                            IdClasseInvestimento = 2
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Opções",
                            IdClasseInvestimento = 2
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "ETFs (Exchange Traded Funds)",
                            IdClasseInvestimento = 2
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Fundos de Investimento em Ações",
                            IdClasseInvestimento = 2
                        },
                        new
                        {
                            Id = 10,
                            Descricao = "Fundos de Renda Fixa",
                            IdClasseInvestimento = 3
                        },
                        new
                        {
                            Id = 11,
                            Descricao = "Fundos Multimercado",
                            IdClasseInvestimento = 3
                        },
                        new
                        {
                            Id = 12,
                            Descricao = "Fundos de Ações",
                            IdClasseInvestimento = 3
                        },
                        new
                        {
                            Id = 13,
                            Descricao = "Fundos Imobiliários",
                            IdClasseInvestimento = 3
                        },
                        new
                        {
                            Id = 14,
                            Descricao = "PGBL (Plano Gerador de Benefício Livre)",
                            IdClasseInvestimento = 4
                        },
                        new
                        {
                            Id = 15,
                            Descricao = "VGBL (Vida Gerador de Benefício Livre)",
                            IdClasseInvestimento = 4
                        },
                        new
                        {
                            Id = 16,
                            Descricao = "COE (Certificado de Operações Estruturadas)",
                            IdClasseInvestimento = 5
                        },
                        new
                        {
                            Id = 17,
                            Descricao = "Investimentos em ativos estrangeiros",
                            IdClasseInvestimento = 6
                        },
                        new
                        {
                            Id = 18,
                            Descricao = "Operações com moedas estrangeiras",
                            IdClasseInvestimento = 7
                        });
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Ordem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Simbolo")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("TipoOrdem")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Ordem", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Agilent",
                            Simbolo = "A",
                            TipoOrdem = "NYSE"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "International Business Machines Corp",
                            Simbolo = "IBM",
                            TipoOrdem = "NYSE"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "iShares iBonds Dec 2024 Term Muni Bond ETF",
                            Simbolo = "IBMM",
                            TipoOrdem = "BATS"
                        });
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("DATETIME");

                    b.Property<int>("OrdemId")
                        .HasColumnType("INT");

                    b.Property<decimal>("PrecoCompra")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("TipoTransacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("OrdemId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContaId")
                        .HasColumnType("INT");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Login")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Senha")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContaId = 1,
                            Email = "admin@admin.com",
                            Login = "admin",
                            Nome = "admin",
                            Senha = "admin@123"
                        });
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.DadosBancario", b =>
                {
                    b.HasOne("FiapTechChallenge.API.Entity.Conta", "Conta")
                        .WithMany("DadosBancarios")
                        .HasForeignKey("ContaId");

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Investimento", b =>
                {
                    b.HasOne("FiapTechChallenge.API.Entity.ClasseInvestimento", "ClasseInvestimento")
                        .WithMany("Investimentos")
                        .HasForeignKey("IdClasseInvestimento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClasseInvestimento");
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Transacao", b =>
                {
                    b.HasOne("FiapTechChallenge.API.Entity.Ordem", "Ordem")
                        .WithMany()
                        .HasForeignKey("OrdemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiapTechChallenge.API.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ordem");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Usuario", b =>
                {
                    b.HasOne("FiapTechChallenge.API.Entity.Conta", "Conta")
                        .WithOne("Usuario")
                        .HasForeignKey("FiapTechChallenge.API.Entity.Usuario", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.ClasseInvestimento", b =>
                {
                    b.Navigation("Investimentos");
                });

            modelBuilder.Entity("FiapTechChallenge.API.Entity.Conta", b =>
                {
                    b.Navigation("DadosBancarios");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
