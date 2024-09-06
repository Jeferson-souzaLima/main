using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAulas.App.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        [DisplayName("Categoria")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Inclusao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
