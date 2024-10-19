using Microsoft.AspNetCore.Mvc;
using GalaxyControl.Models;
using GalaxyControl.Repositories;

namespace GalaxyControl.Controllers;

public class UserController(IUserRepository userRepository) : Controller
{
    private readonly IUserRepository _userRepository = userRepository;

    public IActionResult Index()
    {
        List<UserModel> users = _userRepository.GetAll().Where(x => x.Login != "admin").ToList();
        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        UserModel contato = _userRepository.Get(id);
        return View(contato);
    }

    public IActionResult DeleteConfirmation(int id)
    {
        UserModel contato = _userRepository.Get(id);
        return View(contato);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            bool excluded = _userRepository.Delete(id);

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
    public IActionResult Create(UserModel user)
    {
        try
        {
            if (user.Login == "admin")
            {
                TempData["ErrorMessage"] = $"O login não pode ser igual a 'admin'";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                _userRepository.Create(user);
                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso";
                return RedirectToAction("Index");
            }

            return View(user);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Update(UserUpdateModel userUpdate)
    {
        try
        {
            UserModel? user = null;

            if (userUpdate.Login == "admin")
            {
                TempData["ErrorMessage"] = $"O login não pode ser igual a 'admin'";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                user = new UserModel()
                {
                    Id = userUpdate.Id,
                    Name = userUpdate.Name,
                    Login = userUpdate.Login,
                    Email = userUpdate.Email
                };

                user = _userRepository.Update(user);
                TempData["SuccessMessage"] = "Usuário alterado com sucesso";
                return RedirectToAction("Index");
            }

            return View(user);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }
}