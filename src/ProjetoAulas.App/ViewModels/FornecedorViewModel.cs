using ProjetoAulas.Business.Enums;
using ProjetoAulas.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAulas.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O nome da fornecedor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da fornecedor deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O documento do fornecedor é obrigatório")]
        [StringLength(100, ErrorMessage = "O documento deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Documento { get; set; }
        [DisplayName("Tipo Pessoa")]
        public int TipoPessoa { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Inclusao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }
        public FornecedorEnderecoViewModel Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

    }
}

