using GalaxyControl.Map;
using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyControl.Data;

public class GalaxyControlContext(DbContextOptions<GalaxyControlContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Nave> Naves { get; set; }
    public DbSet<Tripulante> Tripulantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new NaveMap());
        modelBuilder.ApplyConfiguration(new TripulanteMap());

        modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, Nome = "Admin", Email = "galaxycontrol@outlook.com", Login = "Admin", Senha = "1234", DataCadastro = DateTime.Now});

        base.OnModelCreating(modelBuilder);
    }
}