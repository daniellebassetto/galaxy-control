using GalaxyControl.ViewModels;

namespace GalaxyControl.Service;

public interface IUsuarioService
{
    List<UsuarioViewModel>? GetAll();
    UsuarioViewModel? GetById(int id);
    bool Create(UsuarioRegisterViewModel usuarioRegisterViewModel);
    bool Update(UsuarioUpdateViewModel usuarioUpdateViewModel);
    bool Login(LoginViewModel loginViewModel);
    bool ExitSession();
    bool CheckActiveSession();
    bool RedefinePassword(RedefinirSenhaViewModel redefinirSenhaViewModel);
    bool SendLinkToRedefinePassword(RedefinirSenhaPeloLoginViewModel redefinirSenhaPeloLoginViewModel);
}