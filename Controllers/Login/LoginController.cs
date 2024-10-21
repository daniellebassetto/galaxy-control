using GalaxyControl.Helpers;
using GalaxyControl.Models;
using GalaxyControl.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GalaxyControl.Controllers;

public class LoginController(IUsuarioRepository usuarioRepository, Helpers.ISession session, IEmail email) : Controller
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
    private readonly Helpers.ISession _session = session;
    private readonly IEmail _email = email;

    public IActionResult Index()
    {
        if(_session.GetUserSession() != null) 
            return RedirectToAction("Index", "Home");
        return View();
    }

    public IActionResult RedefinirSenha()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Enter(LoginViewModel loginViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = _usuarioRepository.GetLogin(loginViewModel.Login!);

                if (usuario != null)
                {
                    if (usuario.IsValidPassword(loginViewModel.Senha!))
                    {
                        _session.CreateUserSession(JsonConvert.SerializeObject(new UsuarioViewModel() 
                        { 
                            Id = usuario.Id, 
                            Email = usuario.Email,
                            Nome = usuario.Nome,
                            Login = usuario.Login,
                            DataCadastro = usuario.DataCadastro,
                            Senha = usuario.Senha,
                            DataAlteracao = usuario.DataAlteracao
                        }));
                        return RedirectToAction("Index", "Home");
                    }                            

                    TempData["ErrorMessage"] = $"Senha incorreta. Tente novamente.";
                    return View("Index");
                }

                TempData["ErrorMessage"] = $"Usuário e/ou senha inválido(s). Tente novamente.";
            }

            return View("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Exit()
    {
        _session.RemoveUserSession();
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult SendLinkToRedefinePassword(RedefinirSenhaPeloLoginViewModel redefinirSenhaPeloLoginViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = _usuarioRepository.GetLoginAndEmail(redefinirSenhaPeloLoginViewModel.Login, redefinirSenhaPeloLoginViewModel.Email);

                if (usuario != null)
                {
                    string newPassword = usuario.GenerateNewPassword();                        
                    string message = $"Sua nova senha é: {newPassword}";
                    bool emailSent = _email.Send(usuario.Email!, "GalaxyControl - Nova Senha", message);

                    if(emailSent)
                    {
                        _usuarioRepository.Update(usuario);
                        TempData["SuccessMessage"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                    }
                    else
                        TempData["ErrorMessage"] = $"Ocorreu um erro ao enviar o e-mail. Tente novamente.";

                    return RedirectToAction("Index", "Login");
                }

                TempData["ErrorMessage"] = $"Não foi possível redefinir sua senha. Verifique os dados informados.";
            }

            return View("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }
}