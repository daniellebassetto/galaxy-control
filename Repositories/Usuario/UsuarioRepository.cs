using GalaxyControl.Data;
using GalaxyControl.Models;

namespace GalaxyControl.Repositories;

public class UsuarioRepository(GalaxyControlContext dataBaseContext) : IUsuarioRepository
{
    private readonly GalaxyControlContext _dataBaseContext = dataBaseContext;

    public Usuario Create(Usuario user)
    {
        _dataBaseContext.Usuarios.Add(user);
        _dataBaseContext.SaveChanges();
        return user;
    }

    public Usuario? GetById(int id)
    {
        return _dataBaseContext.Usuarios.FirstOrDefault(x => x.Id == id);
    }

    public List<Usuario> GetAll()
    {
        return [.. _dataBaseContext.Usuarios];
    }

    public Usuario? GetByEmail(string email)
    {
        return _dataBaseContext.Usuarios.FirstOrDefault(x => x.Email!.ToUpper() == email.ToUpper());
    }

    public Usuario Update(Usuario usuario)
    {
        _dataBaseContext.Update(usuario);
        _dataBaseContext.SaveChanges();
        return usuario;
    }
}