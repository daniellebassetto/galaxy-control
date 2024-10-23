﻿// <auto-generated />
using System;
using GalaxyControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalaxyControl.Migrations
{
    [DbContext(typeof(GalaxyControlContext))]
    partial class GalaxyControlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GalaxyControl.Models.Nave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Armamento")
                        .HasColumnType("int")
                        .HasColumnName("armamento");

                    b.Property<string>("CodigoRastreio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codigo_rastreio");

                    b.Property<int>("Cor")
                        .HasColumnType("int")
                        .HasColumnName("cor");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEncontro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_encontro");

                    b.Property<int>("GrauAvaria")
                        .HasColumnType("int")
                        .HasColumnName("grau_avaria");

                    b.Property<int>("GrauPericulosidade")
                        .HasColumnType("int")
                        .HasColumnName("grau_periculosidade");

                    b.Property<string>("LocalQueda")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("local_queda");

                    b.Property<int>("PotencialProspeccaoTecnologica")
                        .HasColumnType("int")
                        .HasColumnName("potencial_prospeccao_tecnologica");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int")
                        .HasColumnName("tamanho");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int")
                        .HasColumnName("tipo_combustivel");

                    b.Property<int>("TipoLocalQueda")
                        .HasColumnType("int")
                        .HasColumnName("tipo_local_queda");

                    b.Property<int>("TripulantesFeridos")
                        .HasColumnType("int")
                        .HasColumnName("tripulantes_feridos");

                    b.Property<int>("TripulantesSaudaveis")
                        .HasColumnType("int")
                        .HasColumnName("tripulantes_saudaveis");

                    b.Property<int>("TripulantesSemVida")
                        .HasColumnType("int")
                        .HasColumnName("tripulantes_sem_vida");

                    b.HasKey("Id");

                    b.ToTable("nave", (string)null);
                });

            modelBuilder.Entity("GalaxyControl.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_cadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2024, 10, 23, 16, 54, 14, 106, DateTimeKind.Local).AddTicks(3316),
                            Email = "galaxycontrol@outlook.com",
                            Nome = "Admin",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
