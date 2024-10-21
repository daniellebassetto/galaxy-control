using GalaxyControl.Helpers;
using GalaxyControl.Models;
using GalaxyControl.Repositories;
using GalaxyControl.ViewModels.User;
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
        if (_session.GetUserSession() != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel loginViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Usuario? usuario = _usuarioRepository.GetByEmail(loginViewModel.Email!);

                if (usuario is not null)
                {
                    if (usuario.IsValidPassword(loginViewModel.Senha!))
                    {
                        _session.CreateUserSession(JsonConvert.SerializeObject(new UsuarioViewModel()
                        {
                            Id = usuario.Id,
                            Email = usuario.Email,
                            Nome = usuario.Nome,
                            DataCadastro = usuario.DataCadastro,
                            Senha = usuario.Senha,
                            DataAlteracao = usuario.DataAlteracao
                        }));
                        return RedirectToAction("Index", "Home");
                    }

                    throw new Exception("Senha incorreta. Tente novamente.");
                }

                throw new Exception("Email e/ou senha inválido(s). Tente novamente.");
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

    public IActionResult SendLinkToRedefinePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendLinkToRedefinePassword(RedefinirSenhaPeloLoginViewModel redefinirSenhaPeloLoginViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Usuario? usuario = _usuarioRepository.GetByEmail(redefinirSenhaPeloLoginViewModel.Email!);

                if (usuario is not null)
                {
                    string newPassword = usuario.GenerateNewPassword();
                    string message = $"Sua nova senha é: {newPassword}";
                    bool emailSent = _email.Send(usuario.Email!, "GalaxyControl - Nova Senha", message);

                    if (emailSent)
                    {
                        _usuarioRepository.Update(usuario);
                        TempData["SuccessMessage"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                    }
                    else
                        throw new Exception("Ocorreu um erro ao enviar o e-mail. Tente novamente.");

                    return RedirectToAction("Index", "Login");
                }

                throw new Exception("Não foi possível redefinir sua senha. Verifique os dados informados.");
            }

            return View("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(UsuarioRegisterViewModel usuarioRegisterViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                // verificar se existe alguém já cadastrad com o e-mail informado
                Usuario? usuario = _usuarioRepository.GetByEmail(usuarioRegisterViewModel.Email!);

                if (usuario is not null)
                    throw new Exception("Já existe um usuário com este e-mail");

                // verificar se as senhas coincidem
                if (usuarioRegisterViewModel.Senha == usuarioRegisterViewModel.ConfirmacaoSenha)
                {
                    var novoUsuario = new Usuario()
                    {
                        Nome = usuarioRegisterViewModel.Nome,
                        Email = usuarioRegisterViewModel.Email,
                        Senha = usuarioRegisterViewModel.Senha,
                        DataCadastro = DateTime.Now
                    };

                    novoUsuario.SetHashPassword();
                    _usuarioRepository.Create(novoUsuario);

                    TempData["SuccessMessage"] = "Cadastro realizado com sucesso. Realize o login.";
                    return RedirectToAction("Index");
                }
                else
                    throw new Exception("As senhas não coincidem");
            }

            return View(usuarioRegisterViewModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult RedefinePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RedefinePassword(RedefinirSenhaViewModel redefinirSenhaViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Usuario? usuario = _session.GetUserSession();

                if (usuario is not null)
                {
                    if (!usuario.IsValidPassword(redefinirSenhaViewModel.SenhaAtual!))
                        throw new Exception("Senha atual incorreta");

                    if (usuario.IsValidPassword(redefinirSenhaViewModel.NovaSenha!))
                        throw new Exception("Nova senha deve ser diferente da senha atual");

                    if (redefinirSenhaViewModel.NovaSenha != redefinirSenhaViewModel.ConfirmacaoNovaSenha)
                        throw new Exception("Nova senha não coincide com a confirmação de senha");

                    usuario.SetNewPassword(redefinirSenhaViewModel.NovaSenha!);
                    usuario.DataAlteracao = DateTime.Now;

                    _usuarioRepository.Update(usuario);

                    TempData["SuccessMessage"] = "Senha atualizada com sucesso";
                }
                else
                    throw new Exception("Usuário não encontrado");
            }

            return View(redefinirSenhaViewModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index", "Home");
        }
    }
}