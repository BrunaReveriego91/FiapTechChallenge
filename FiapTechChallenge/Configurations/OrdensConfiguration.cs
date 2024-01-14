using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapTechChallenge.API.Configurations
{
    public class OrdensConfiguration : IEntityTypeConfiguration<Ordem>
    {
        public void Configure(EntityTypeBuilder<Ordem> builder)
        {
            builder.ToTable("Ordem");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Simbolo).HasColumnType("VARCHAR(10)");
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(255)");
            builder.Property(p => p.TipoOrdem).HasColumnType("VARCHAR(255)");
        }
    }
}
