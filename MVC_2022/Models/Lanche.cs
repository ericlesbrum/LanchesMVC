using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_2022.Models;
[Table("Lanches")]
public class Lanche
{
    [Key]
    public int LancheId { get; set; }
    [StringLength(80,MinimumLength =10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
    [Required(ErrorMessage = "O nome do lanche deve ser informado")]
    [Display(Name = "Nome do Lanche")]
    public string LancheNome { get; set; }
    [StringLength(200, MinimumLength = 20, ErrorMessage = "A {0} deve ter no mínimo {1} e no máximo {2}")]
    [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
    [Display(Name = "Descrição do Lanche")]
    public string DescricaoCurta { get; set; }
    [StringLength(200, MinimumLength = 20, ErrorMessage = "A {0} deve ter no mínimo {1} e no máximo {2}")]
    [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informado")]
    [Display(Name = "Descrição detalhada do Lanche")]
    public string DescricaoDetalhada { get; set; }
    [Required(ErrorMessage = "Informe o preço do Lanche")]
    [Display(Name ="Preço")]
    [Column(TypeName ="decimal(10,2)")]
    [Range(1,999.99,ErrorMessage ="O premo deve estar entre 1 e 999,99")]
    public decimal Preco { get; set; }
    [Display(Name = "Caminho Imagem Normal")]
    [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {2}")]
    public string ImagemUrl { get; set; }
    [Display(Name = "Caminho Imagem Miniatura")]
    [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {2}")]
    public string ImagemThumbnailUrl { get; set; }
    [Display(Name ="Preferido?")]
    public bool IsLanchePreferido { get; set; }
    [Display(Name = "Estoque")]
    public bool EmEstoque { get; set; }

    //Propriedades de navegação
    [Display(Name = "Categorias")]
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}
