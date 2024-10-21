using GalaxyControl.Models;

namespace GalaxyControl.Repositories;

public interface IUsuarioRepository
{
    Usuario Create(Usuario usuario);
    Usuario? Get(long id);
    List<Usuario>? GetAll();
    Usuario? GetByEmail(string email);
    Usuario Update(Usuario usuario);
}