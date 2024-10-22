﻿using GalaxyControl.Models;
using GalaxyControl.ViewModels;

namespace GalaxyControl.Services;

public interface IUsuarioService
{
    bool Create(UsuarioRegisterViewModel usuarioRegisterViewModel);
    bool Login(LoginViewModel loginViewModel);
    bool ExitSession();
    bool CheckActiveSession();
    bool RedefinePassword(RedefinirSenhaViewModel redefinirSenhaViewModel);
    bool SendLinkToRedefinePassword(RedefinirSenhaPeloLoginViewModel redefinirSenhaPeloLoginViewModel);
}