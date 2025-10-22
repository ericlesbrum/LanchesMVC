using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_2022.Controllers;

[Authorize]
public class ContatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
