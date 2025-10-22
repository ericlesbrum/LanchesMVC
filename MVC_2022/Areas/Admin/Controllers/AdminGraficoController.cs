using Microsoft.AspNetCore.Mvc;
using MVC_2022.Areas.Admin.Services;
using NuGet.Protocol;

namespace MVC_2022.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminGraficoController : Controller
{
    private readonly GraficoVendaService _graficoVendaService;

    public AdminGraficoController(GraficoVendaService graficoVendaService)
    {
        _graficoVendaService = graficoVendaService;
    }

    public JsonResult VendasLanches(int dias)
    {
        var lanchesVendasTotais = _graficoVendaService.GetVendasLanche(dias);
        return Json(lanchesVendasTotais);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult VendasMensal()
    {
        return View();
    }

    [HttpGet]
    public IActionResult VendasSemanal()
    {
        return View();
    }
}
