using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapTechChallenge.API.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Email).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Login).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(100)");
        }
    }
}
