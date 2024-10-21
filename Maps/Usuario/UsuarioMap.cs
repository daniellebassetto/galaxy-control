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

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Nome).HasColumnName("nome");
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.Nome).HasMaxLength(50);
        builder.Property(x => x.Nome).ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(256);
        builder.Property(x => x.Email).ValueGeneratedNever();

        builder.Property(x => x.Login).HasColumnName("login");
        builder.Property(x => x.Login).IsRequired();
        builder.Property(x => x.Login).HasMaxLength(256);
        builder.Property(x => x.Login).ValueGeneratedNever();

        builder.Property(x => x.Senha).HasColumnName("senha");
        builder.Property(x => x.Senha).IsRequired();
        builder.Property(x => x.Senha).HasMaxLength(100);
        builder.Property(x => x.Senha).ValueGeneratedNever();

        builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");
        builder.Property(x => x.DataCadastro).IsRequired();
        builder.Property(x => x.DataCadastro).ValueGeneratedNever();

        builder.Property(x => x.DataAlteracao).HasColumnName("data_alteracao");
        builder.Property(x => x.DataAlteracao).ValueGeneratedNever();
    }
}