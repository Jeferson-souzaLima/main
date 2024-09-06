using ProjetoAulas.Business.Enums;

namespace ProjetoAulas.Business.Models
{
    public class Fornecedor : BaseEntity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public bool Ativo { get; set; }

        /* EF Relational */
        public FornecedorEndereco Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
