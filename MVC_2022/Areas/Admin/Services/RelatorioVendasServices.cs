using Microsoft.EntityFrameworkCore;
using MVC_2022.Context;
using MVC_2022.Models;

namespace MVC_2022.Areas.Admin.Services;

public class RelatorioVendasServices
{
    private readonly AppDbContext _context;

    public RelatorioVendasServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        var result = from pedidos in _context.Pedidos
                     select pedidos;

        if (minDate.HasValue)
            result = result.Where(x => x.PedidoEnviado >= minDate.Value);

        if (maxDate.HasValue)
            result = result.Where(x => x.PedidoEnviado <= maxDate.Value);

        return await result
            .Include(l => l.PedidoItens)
            .ThenInclude(l => l.Lanche)
            .OrderByDescending(x => x.PedidoEnviado)
            .ToListAsync();
    }
}
