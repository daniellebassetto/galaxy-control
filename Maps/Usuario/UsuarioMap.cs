using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyControl.Map;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(50).ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(256).ValueGeneratedNever();

        builder.Property(x => x.Login).HasColumnName("login").IsRequired().HasMaxLength(256).ValueGeneratedNever();

        builder.Property(x => x.Senha).HasColumnName("senha").IsRequired().HasMaxLength(100).ValueGeneratedNever();

        builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.DataAlteracao).HasColumnName("data_alteracao").ValueGeneratedNever();
    }
}