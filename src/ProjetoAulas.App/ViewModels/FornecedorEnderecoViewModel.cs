using Microsoft.AspNetCore.Mvc;
using ProjetoAulas.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAulas.App.ViewModels
{
    public class FornecedorEnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(8, ErrorMessage = "O CEP deve ter {1} caracteres.", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome estado deve ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "A cidade deve ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Bairro deve ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Logradouro deve ter entre {1} e {2} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Numero é obrigatório.")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public DateTime Inclusao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }
        [HiddenInput]
        public Guid FornecedorId { get; set; }

    }
}
