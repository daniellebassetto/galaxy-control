using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyControl.Map;

public class TripulanteMap : IEntityTypeConfiguration<Tripulante>
{
    public void Configure(EntityTypeBuilder<Tripulante> builder)
    {
        builder.ToTable("tripulante");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(100);

        builder.Property(x => x.Estado).HasColumnName("estado").IsRequired();

        builder.Property(x => x.NaveId).HasColumnName("id_nave").IsRequired();

        builder.HasOne(x => x.Nave).WithMany(x => x.Tripulante).HasForeignKey(x => x.NaveId).OnDelete(DeleteBehavior.Cascade);
    }
}