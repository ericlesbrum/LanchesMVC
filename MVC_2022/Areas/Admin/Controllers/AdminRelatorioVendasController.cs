﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_2022.Areas.Admin.Services;

namespace MVC_2022.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize("Admin")]
public class AdminRelatorioVendasController : Controller
{
    private readonly RelatorioVendasServices relatorioVendasServices;

    public AdminRelatorioVendasController(RelatorioVendasServices relatorioVendasServices)
    {
        this.relatorioVendasServices = relatorioVendasServices;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
    {
        if (!minDate.HasValue)
        {
            minDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }

        ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

        var result = await relatorioVendasServices.FindByDateAsync(minDate, maxDate);
        return View(result);
    }
}
