using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ClasseInvestimento> ClasseInvestimento { get; set; }
        public DbSet<Investimento> Investimento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<DadosBancario> DadosBancario { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Ordem> Ordem { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<ClasseInvestimento>().HasData(
                new ClasseInvestimento
                {
                    Id = 1,
                    Descricao = "Renda Fixa"
                },
                new ClasseInvestimento
                {
                    Id = 2,
                    Descricao = "Renda Variável"
                },
                new ClasseInvestimento
                {
                    Id = 3,
                    Descricao = "Fundos de Investimento"
                },
                new ClasseInvestimento
                {
                    Id = 4,
                    Descricao = "Previdência Privada"
                },
                new ClasseInvestimento
                {
                    Id = 5,
                    Descricao = "COE (Certificado de Operações Estruturadas)"
                },
                new ClasseInvestimento
                {
                    Id = 6,
                    Descricao = "Operações no Mercado Internacional"
                },
                new ClasseInvestimento
                {
                    Id = 7,
                    Descricao = "Câmbio"
                });


            modelBuilder.Entity<Investimento>().HasData(
                new Investimento { Id = 1, Descricao = "Tesouro Direto", IdClasseInvestimento = 1 },
                new Investimento { Id = 2, Descricao = "CDB (Certificado de Depósito Bancário)", IdClasseInvestimento = 1 },
                new Investimento { Id = 3, Descricao = "LCI (Letra de Crédito Imobiliário)", IdClasseInvestimento = 1 },
                new Investimento { Id = 4, Descricao = "LCA (Letra de Crédito do Agronegócio)", IdClasseInvestimento = 1 },
                new Investimento { Id = 5, Descricao = "Debêntures", IdClasseInvestimento = 1 },
                new Investimento { Id = 6, Descricao = "Ações", IdClasseInvestimento = 2 },
                new Investimento { Id = 7, Descricao = "Opções", IdClasseInvestimento = 2 },
                new Investimento { Id = 8, Descricao = "ETFs (Exchange Traded Funds)", IdClasseInvestimento = 2 },
                new Investimento { Id = 9, Descricao = "Fundos de Investimento em Ações", IdClasseInvestimento = 2 },
                new Investimento { Id = 10, Descricao = "Fundos de Renda Fixa", IdClasseInvestimento = 3 },
                new Investimento { Id = 11, Descricao = "Fundos Multimercado", IdClasseInvestimento = 3 },
                new Investimento { Id = 12, Descricao = "Fundos de Ações", IdClasseInvestimento = 3 },
                new Investimento { Id = 13, Descricao = "Fundos Imobiliários", IdClasseInvestimento = 3 },
                new Investimento { Id = 14, Descricao = "PGBL (Plano Gerador de Benefício Livre)", IdClasseInvestimento = 4 },
                new Investimento { Id = 15, Descricao = "VGBL (Vida Gerador de Benefício Livre)", IdClasseInvestimento = 4 },
                new Investimento { Id = 16, Descricao = "COE (Certificado de Operações Estruturadas)", IdClasseInvestimento = 5 },
                new Investimento { Id = 17, Descricao = "Investimentos em ativos estrangeiros", IdClasseInvestimento = 6 },
                new Investimento { Id = 18, Descricao = "Operações com moedas estrangeiras", IdClasseInvestimento = 7 }
            );

            modelBuilder.Entity<Conta>().HasData(
                              new Conta {
                                  Id = 1,
                                  NumeroConta = 1111,
                                  CPF = "11111111111",
                                  Nome = "Admin",
                                  Email = "admin@admin.com",
                                  NomeMae = "Maria",
                                  NomePai = "José",
                                  Renda = 0,
                                  CEP = "1200000",
                                  Logradouro = "Rua Sem Nome",
                                  Numero = 1,
                                  Complemento = "Casa",
                                  Bairro = "Centro",
                                  Cidade = "São Paulo",
                                  Estado = "SP",
                                  Ativo = true
                              });

            modelBuilder.Entity<Usuario>().HasData(
                               new Usuario { Id = 1, ContaId = 1, Nome = "admin", Email = "admin@admin.com", Login = "admin", Senha = "admin@123" });

            modelBuilder.Entity<Ordem>().HasData(
                    new Ordem { Id = 1, Nome = "Agilent", Simbolo = "A", TipoOrdem = "NYSE" },
                    new Ordem { Id = 2, Nome = "International Business Machines Corp", Simbolo = "IBM", TipoOrdem = "NYSE" },
                    new Ordem { Id = 3, Nome = "iShares iBonds Dec 2024 Term Muni Bond ETF", Simbolo = "IBMM", TipoOrdem = "BATS" }
                );
        }
    }
}
