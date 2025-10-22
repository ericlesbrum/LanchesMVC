using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repository.Interfaces;
using MVC_2022.ViewModels;

namespace MVC_2022.Controllers;

public class CarrinhoCompraController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItens = itens;

        var carrinhoCompraVm = new CarrinhoCompraViewModel
        {
            carrinhoCompra = _carrinhoCompra,
            carrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };

        return View(carrinhoCompraVm);
    }

    [Authorize]
    public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
    {
        var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(lanche => lanche.LancheId == lancheId);
        if (lancheSelecionado != null)
            _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);

        return RedirectToAction("Index");
    }

    [Authorize]
    public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
    {
        var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(lanche => lanche.LancheId == lancheId);
        if (lancheSelecionado != null)
            _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

        return RedirectToAction("Index");
    }
}
