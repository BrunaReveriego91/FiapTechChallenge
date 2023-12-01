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

        }
    }
}
