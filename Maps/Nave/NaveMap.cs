﻿using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyControl.Map;

public class NaveMap : IEntityTypeConfiguration<Nave>
{
    public void Configure(EntityTypeBuilder<Nave> builder)
    {
        builder.ToTable("nave");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.CodigoRastreio).HasColumnName("codigo_rastreio").IsRequired().HasMaxLength(50);

        builder.Property(x => x.DataQueda).HasColumnName("data_queda").IsRequired();

        builder.Property(x => x.Tamanho).HasColumnName("tamanho").IsRequired();

        builder.Property(x => x.Cor).HasColumnName("cor").IsRequired();

        builder.Property(x => x.TipoLocalQueda).HasColumnName("tipo_local_queda").IsRequired();

        builder.Property(x => x.LocalQueda).HasColumnName("local_queda").IsRequired().HasMaxLength(100);

        builder.Property(x => x.Armamento).HasColumnName("armamento").IsRequired();

        builder.Property(x => x.TipoCombustivel).HasColumnName("tipo_combustivel").IsRequired();

        builder.HasMany(x => x.Tripulante).WithOne(x => x.Nave).HasForeignKey(x => x.NaveId).OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.GrauAvaria).HasColumnName("grau_avaria").IsRequired();

        builder.Property(x => x.PotencialProspeccaoTecnologica).HasColumnName("potencial_prospeccao_tecnologica").IsRequired();

        builder.Property(x => x.GrauPericulosidade).HasColumnName("grau_periculosidade").IsRequired();
    }
}