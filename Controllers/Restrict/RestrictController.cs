using Microsoft.AspNetCore.Mvc;

namespace GalaxyControl.Controllers.Restrict;

public class RestrictController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}