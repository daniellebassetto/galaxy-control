using GalaxyControl.Models;
using GalaxyControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class RedefinePasswordController(IUsuarioRepository userRepository, Helpers.ISession session) : Controller
{
    private readonly IUsuarioRepository _userRepository = userRepository;
    private readonly Helpers.ISession _session = session;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(RedefinirSenhaViewModel redefinirSenhaViewModel)
    {
        try
        {
            Usuario usuario = _session.GetUserSession()!;
            redefinirSenhaViewModel.UserId = usuario.Id;

            if (ModelState.IsValid)
            {
                _userRepository.RedefinePassword(redefinirSenhaViewModel);
                TempData["SuccessMessage"] = "Senha alterada com sucesso";
                return View("Index", redefinirSenhaViewModel);
            }

            return View("Index", redefinirSenhaViewModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return View("Index", redefinirSenhaViewModel);
        }
    }
}