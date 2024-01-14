using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapTechChallenge.API.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Quantidade).HasColumnType("INT");
            builder.Property(p => p.PrecoCompra).HasColumnType("DECIMAL(18, 2)");
            builder.Property(p => p.DataTransacao).HasColumnType("DATETIME");
            builder.Property(p => p.TipoTransacao).HasConversion<string>();
            builder.Property(p => p.Status).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.UsuarioId).HasColumnType("INT");
            builder.Property(p => p.OrdemId).HasColumnType("INT");

            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);

            builder.HasOne(p => p.Ordem)
                .WithMany()
                .HasForeignKey(p => p.OrdemId);
        }
    }
}
