using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers;

public class PatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}