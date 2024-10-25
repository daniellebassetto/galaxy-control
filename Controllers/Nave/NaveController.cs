using GalaxyControl.Helpers.Pagination;
using GalaxyControl.Services;
using GalaxyControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class NaveController(INaveService service) : Controller
{
    private readonly INaveService _service = service;

    public IActionResult Index(int pageNumber = 1, int pageSize = 6)
    {
        List<NaveViewModel>? naves = _service.GetAll()?.OrderByDescending(x => x.Id).ToList();
        var paginatedList = PaginatedList<NaveViewModel>.Create(naves, pageNumber, pageSize);

        return View(paginatedList);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        NaveViewModel nave = _service.GetById(id)!;

        AtualizarNaveViewModel model = new AtualizarNaveViewModel()
        {
            Id = id,
            DataEncontro = nave.DataEncontro,
            Tamanho = nave.Tamanho,
            Cor = nave.Cor,
            TipoLocalQueda = nave.TipoLocalQueda,
            LocalQueda = nave.LocalQueda,
            Armamento = nave.Armamento,
            TipoCombustivel = nave.TipoCombustivel,
            TripulantesFeridos = nave.TripulantesFeridos,
            TripulantesSaudaveis = nave.TripulantesSaudaveis,
            TripulantesSemVida = nave.TripulantesSemVida,
            GrauAvaria = nave.GrauAvaria,
            PotencialProspeccaoTecnologica = nave.PotencialProspeccaoTecnologica,
            GrauPericulosidade = nave.GrauPericulosidade,
            Classificacao = nave.Classificacao
        };

        return View(model);
    }

    public IActionResult View(int id)
    {
        NaveViewModel nave = _service.GetById(id)!;
        return View(nave);
    }

    public IActionResult DeleteConfirmation(int id)
    {
        NaveViewModel nave = _service.GetById(id)!;
        return PartialView(nave);
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

    [HttpPost]
    public IActionResult ClassificarNave(CriarNaveViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var classificacoes = _service.ClassificarNave(
                           model.GrauAvaria,
                           model.PotencialProspeccaoTecnologica,
                           model.Armamento,
                           model.GrauPericulosidade,
                           model.TipoCombustivel
                           );

                return PartialView("_ClassificacaoPartial", classificacoes);
            }
            return View(model);
        }
        catch (Exception ex) 
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }
}