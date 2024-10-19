using GalaxyControl.Models;
using GalaxyControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class RedefinePasswordController(IUserRepository userRepository, Helpers.ISession session) : Controller
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly Helpers.ISession _session = session;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(RedefinePasswordModel redefinePasswordModel)
    {
        try
        {
            UserModel userModel = _session.GetUserSession()!;
            redefinePasswordModel.UserId = userModel.Id;

            if (ModelState.IsValid)
            {
                _userRepository.RedefinePassword(redefinePasswordModel);
                TempData["SuccessMessage"] = "Senha alterada com sucesso";
                return View("Index", redefinePasswordModel);
            }

            return View("Index", redefinePasswordModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return View("Index", redefinePasswordModel);
        }
    }
}