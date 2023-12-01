using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapTechChallenge.API.Configurations
{
    public class InvestimentoConfiguration : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.ToTable("Investimento");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(100)");
            builder.HasOne(c => c.ClasseInvestimento)
                .WithMany(inv => inv.Investimentos)
                .HasPrincipalKey(u => u.Id);

        }
    }
}
