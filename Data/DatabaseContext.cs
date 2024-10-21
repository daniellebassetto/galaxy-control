using GalaxyControl.Map;
using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyControl.Data;

public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());

        modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, Nome = "Admin", Email = "galaxycontrol@outlook.com", Login = "Admin", Senha = "1234", DataCadastro = DateTime.Now});

        base.OnModelCreating(modelBuilder);
    }
}