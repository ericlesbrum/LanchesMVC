using Microsoft.EntityFrameworkCore;
using MVC_2022.Context;
using MVC_2022.Models;
using MVC_2022.Repository.Interfaces;

namespace MVC_2022.Repository;

public class LancheRepository : ILancheRepository
{
    private readonly AppDbContext _context;

    public LancheRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Lanche> Lanches => _context.Lanches.Include(categoria=>categoria.Categoria);

    public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
        .Where(lanche=>lanche.IsLanchePreferido)
        .Include(categoria=> categoria.Categoria);

    public Lanche GetLancheById(int id)
    {
        return _context.Lanches.FirstOrDefault(lanche => lanche.LancheId == id);
    }
}
