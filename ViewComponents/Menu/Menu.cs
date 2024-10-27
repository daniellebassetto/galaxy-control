using GalaxyControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GalaxyControl.ViewComponents;

public class Menu : ViewComponent
{
    public IViewComponentResult? Invoke()
    {
        string? userSession = HttpContext.Session.GetString("loggedUserSession");

        if (string.IsNullOrEmpty(userSession))
            throw new UnauthorizedAccessException("User is not logged in.");

        UsuarioViewModel user = JsonConvert.DeserializeObject<UsuarioViewModel>(userSession)!;

        return View(user);
    }
}