using GalaxyControl.Services;
using GalaxyControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class LoginController(IUsuarioService usuarioService) : Controller
{
    private readonly IUsuarioService _usuarioService = usuarioService;

    public IActionResult Index()
    {
        if (_usuarioService.CheckActiveSession())
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
                _usuarioService.Login(loginViewModel);
                return RedirectToAction("Index", "Home");
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
        _usuarioService.ExitSession();
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
                _usuarioService.SendLinkToRedefinePassword(redefinirSenhaPeloLoginViewModel);
                TempData["SuccessMessage"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                return RedirectToAction("Index", "Login");
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
                _usuarioService.Create(usuarioRegisterViewModel);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso. Realize o login.";
                return RedirectToAction("Index");
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
                _usuarioService.RedefinePassword(redefinirSenhaViewModel);
                TempData["SuccessMessage"] = "Senha atualizada com sucesso";
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