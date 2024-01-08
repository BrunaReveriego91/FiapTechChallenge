using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapTechChallenge.API.Configurations
{
    public class DadosBancarioConfiguration : IEntityTypeConfiguration<DadosBancario>
    {
        public void Configure(EntityTypeBuilder<DadosBancario> builder)
        {
            builder.ToTable("DadosBancarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.CodigoBanco).HasColumnType("VARCHAR(10)");
            builder.Property(p => p.NumeroConta).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.Agencia).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.IdConta).HasColumnType("INT");
        }
    }
}
