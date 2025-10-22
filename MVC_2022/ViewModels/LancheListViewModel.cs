using MVC_2022.Models;

namespace MVC_2022.ViewModels;

public class LancheListViewModel
{
    public IEnumerable<Lanche> lanches{ get; set; }
    public string categoriaAtual { get; set; }
}
