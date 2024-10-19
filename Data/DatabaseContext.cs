using GalaxyControl.Map;
using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyControl.Data;

public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
{
    public DbSet<UserModel> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());

        modelBuilder.Entity<UserModel>().HasData(new UserModel { Id = 1, Name = "Admin", Email = "galaxycontrol@outlook.com", Login = "Admin", Password = "1234", RegistrationDate = DateTime.Now});

        base.OnModelCreating(modelBuilder);
    }
}