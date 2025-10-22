using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repository.Interfaces;
using MVC_2022.ViewModels;

namespace MVC_2022.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _repository;

        public LancheController(ILancheRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categorialAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _repository.Lanches.OrderBy(l => l.LancheId);
                categorialAtual = "Todos os lanches";
            }
            else
            {
                lanches = _repository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria)).OrderBy(c => c.LancheNome);
                categorialAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                categoriaAtual = categoria,
                lanches = lanches
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _repository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }

        public IActionResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categorialAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _repository.Lanches.OrderBy(l => l.LancheId);
                categorialAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _repository.Lanches.Where(l => l.LancheNome.ToLower().Contains(searchString.ToLower()));
                if (lanches.Any())
                {
                    categorialAtual = "Lanches";
                }
                else
                {
                    categorialAtual = "Nenhum lanche foi encontrado";
                }
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                lanches = lanches,
                categoriaAtual = categorialAtual
            });
        }
    }
}