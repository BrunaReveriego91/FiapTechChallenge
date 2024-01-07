using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Configurations
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.NumeroConta).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(11)");
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Email).HasColumnType("VARCHAR(250)");
            builder.Property(p => p.NomeMae).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.NomePai).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Renda).HasColumnType("NUMERIC(15,2)");
            builder.Property(p => p.CEP).HasColumnType("VARCHAR(100)"); 
            builder.Property(p => p.Logradouro).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Numero).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Complemento).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Bairro).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Cidade).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Estado).HasColumnType("VARCHAR(2)");
            builder.Property(p => p.Ativo).HasColumnType("BIT");            
        }
    }
}
