using Microsoft.AspNetCore.Mvc;
using GalaxyControl.Models;
using GalaxyControl.Repositories;

namespace GalaxyControl.Controllers;

public class UsuarioController(IUsuarioRepository usuarioRepository) : Controller
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public IActionResult Index()
    {
        List<Usuario>? usuarios = _usuarioRepository.GetAll()?.Where(x => x.Email != "galaxycontrol@outlook.com").ToList();

        var usuariosViewModel = usuarios?.Select(x => new UsuarioViewModel()
        {
            Id = x.Id,
            Nome = x.Nome,
            Email = x.Email
        }).ToList();

        return View(usuariosViewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        Usuario? usuario = _usuarioRepository.Get(id);
        return View(usuario);
    }

    [HttpPost]
    public IActionResult Create(UsuarioViewModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.Create(new Usuario() { Email = usuario.Email, Nome = usuario.Nome, Senha = usuario.Senha, DataCadastro = usuario.DataCadastro });
                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso";
                return RedirectToAction("Index");
            }

            return View(usuario);
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
                Usuario usuario = _usuarioRepository.Get(usuarioUpdateViewModel.Id) ?? throw new Exception("Usuário inválido ou inexistente");

                usuario.Nome = usuarioUpdateViewModel.Nome;
                usuario.Email = usuarioUpdateViewModel.Email;
                usuario.DataAlteracao = DateTime.Now;

                _usuarioRepository.Update(usuario);
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