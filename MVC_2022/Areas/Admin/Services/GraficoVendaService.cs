﻿using MVC_2022.Context;
using MVC_2022.Models;

namespace MVC_2022.Areas.Admin.Services;

public class GraficoVendaService
{
    private readonly AppDbContext _context;

    public GraficoVendaService(AppDbContext context)
    {
        _context = context;
    }

    public List<LancheGrafico> GetVendasLanche(int dias = 360)
    {
        var data = DateTime.Now.AddDays(-dias);

        var lanches = (from pd in _context.PedidoDetalhes
                       join l in _context.Lanches on pd.LancheId equals l.LancheId
                       where pd.Pedido.PedidoEnviado >= data
                       group pd by new { pd.LancheId, l.LancheNome}
                       into g
                       select new LancheGrafico
                       {
                           LancheNome = g.Key.LancheNome,
                           LanchesQuantidade = g.Sum(q => q.Quantidade),
                           LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade),
                       }
                       ).ToList();

        return lanches;
    }
}
