using GalaxyControl.Services;
using GalaxyControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class NaveController(INaveService service) : Controller
{
    private readonly INaveService _service = service;

    public IActionResult Index()
    {
        List<NaveViewModel>? naves = _service.GetAll();
        return View(naves);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        NaveViewModel nave = _service.GetById(id)!;
        return View(nave);
    }

    public IActionResult DeleteConfirmation(int id)
    {
        NaveViewModel nave = _service.GetById(id)!;
        return View(nave);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _service.Delete(id);
            TempData["SuccessMessage"] = "Nave excluído com sucesso";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Create(CriarNaveViewModel criarNaveViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _service.Create(criarNaveViewModel);
                TempData["SuccessMessage"] = "Nave cadastrada com sucesso";
                return RedirectToAction("Index");
            }
            return View(criarNaveViewModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Update(AtualizarNaveViewModel atualizarNaveViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _service.Update(atualizarNaveViewModel);
                TempData["SuccessMessage"] = "Nave alterada com sucesso";
                return RedirectToAction("Index");
            }
            return View(atualizarNaveViewModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    //[HttpGet]
    //public IActionResult ShowAttributes(int id)
    //{
    //    NaveViewModel nave = _service.GetById(id)!;
    //    return PartialView("_ShowAttributes", nave);
    //}
}