using ProjetoAulas.Business.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAulas.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória")]
        [StringLength(100, ErrorMessage = "A descrição do produto deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public IFormFile ImageUpload { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O valor do produto é obrigatório")]
        public decimal Valor { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        [Required(ErrorMessage = "O fornecedor é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Inclusao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }

        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }


    }
}

