using GalaxyControl.Map;
using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyControl.Data;

public class GalaxyControlContext(DbContextOptions<GalaxyControlContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Nave> Naves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new NaveMap());

        modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, Nome = "Admin", Email = "galaxycontrol@outlook.com", Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220", DataCadastro = DateTime.Now });

        base.OnModelCreating(modelBuilder);
    }
}