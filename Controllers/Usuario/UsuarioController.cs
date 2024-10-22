using GalaxyControl.Service;
using GalaxyControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class UsuarioController(IUsuarioService usuarioService) : Controller
{
    private readonly IUsuarioService _usuarioService = usuarioService;

    public IActionResult Index()
    {
        var usuarios = _usuarioService.GetAll();
        return View(usuarios);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        UsuarioViewModel? usuario = _usuarioService.GetById(id);
        return View(usuario);
    }

    [HttpPost]
    public IActionResult Create(UsuarioRegisterViewModel usuarioRegisterViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Create(usuarioRegisterViewModel);
                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso";
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

    [HttpPost]
    public IActionResult Update(UsuarioUpdateViewModel usuarioUpdateViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Update(usuarioUpdateViewModel);
                TempData["SuccessMessage"] = "Usuário alterado com sucesso";
                return RedirectToAction("Index");
            }

            return View(usuarioUpdateViewModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }
}