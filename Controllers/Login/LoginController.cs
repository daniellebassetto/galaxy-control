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

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegistrarUsuarioViewModel registrarUsuarioViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Create(registrarUsuarioViewModel);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso. Realize o login.";
                return RedirectToAction("Index");
            }
            return View(registrarUsuarioViewModel);
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