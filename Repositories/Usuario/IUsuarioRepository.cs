using GalaxyControl.Models;

namespace GalaxyControl.Repositories;

public interface IUsuarioRepository
{
    Usuario Create(Usuario usuario);
    bool Delete(long id);
    Usuario Get(long id);
    List<Usuario> GetAll();
    Usuario GetLogin(string login);
    Usuario GetLoginAndEmail(string login, string email);
    Usuario RedefinePassword(RedefinirSenhaViewModel redefinirSenhaViewModel);
    Usuario Update(Usuario usuario);
}