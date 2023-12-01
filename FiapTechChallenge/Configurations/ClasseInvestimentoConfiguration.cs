using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapTechChallenge.API.Configurations
{
    public class ClasseInvestimentoConfiguration : IEntityTypeConfiguration<ClasseInvestimento>
    {
        public void Configure(EntityTypeBuilder<ClasseInvestimento> builder)
        {
            builder.ToTable("ClasseInvestimento");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(100)");
        }
    }
}
