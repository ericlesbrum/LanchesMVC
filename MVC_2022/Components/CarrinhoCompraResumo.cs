using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.ViewModels;

namespace MVC_2022.Components;

public class CarrinhoCompraResumo : ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItens = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel
        {
            carrinhoCompra = _carrinhoCompra,
            carrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
        };

        return View(carrinhoCompraVM);
    }
}
