using Microsoft.AspNetCore.Mvc;
using GalaxyControl.Models;
using GalaxyControl.Repositories;

namespace GalaxyControl.Controllers;

public class UsuarioController(IUsuarioRepository usuarioRepository) : Controller
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public IActionResult Index()
    {
        List<Usuario> usuarios = _usuarioRepository.GetAll().Where(x => x.Login != "admin").ToList();

        var usuarioViewModel = usuarios.Select(x => new UsuarioViewModel()
        {
            Id = x.Id,
            Nome = x.Nome,
            Login = x.Login,
            Email = x.Email
        }).ToList();

        return View(usuarios);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        Usuario usuario = _usuarioRepository.Get(id);
        return View(usuario);
    }

    public IActionResult DeleteConfirmation(int id)
    {
        Usuario usuario = _usuarioRepository.Get(id);
        return View(usuario);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            bool excluded = _usuarioRepository.Delete(id);

            if (excluded)
                TempData["SuccessMessage"] = "Usuário excluído com sucesso";
            else
                TempData["ErrorMessage"] = $"Erro: não foi possível apagar este usuário";

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }

    }

    [HttpPost]
    public IActionResult Create(UsuarioViewModel usuario)
    {
        try
        {
            if (usuario.Login == "admin")
            {
                TempData["ErrorMessage"] = $"O login não pode ser igual a 'admin'";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                _usuarioRepository.Create(new Usuario() { Login = usuario.Login, Email = usuario.Email, Nome = usuario.Nome, Senha = usuario.Senha, DataCadastro = usuario.DataCadastro });
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
    public IActionResult Update(UsuarioUpdateViewModel usuarioUpdate)
    {
        try
        {
            Usuario? usuario = null;

            if (usuarioUpdate.Login == "admin")
            {
                TempData["ErrorMessage"] = $"O login não pode ser igual a 'admin'";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                usuario = new Usuario()
                {
                    Id = usuarioUpdate.Id,
                    Nome = usuarioUpdate.Nome,
                    Login = usuarioUpdate.Login,
                    Email = usuarioUpdate.Email
                };

                usuario = _usuarioRepository.Update(usuario);
                TempData["SuccessMessage"] = "Usuário alterado com sucesso";
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
}