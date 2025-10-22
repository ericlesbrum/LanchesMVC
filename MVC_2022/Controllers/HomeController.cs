using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repository.Interfaces;
using MVC_2022.ViewModels;

namespace MVC_2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILogger<HomeController> logger, ILancheRepository lancheRepository)
        {
            _logger = logger;
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var lanchesPreferidos = new HomeViewModel
            {
                lanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(lanchesPreferidos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
