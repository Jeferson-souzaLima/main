namespace ProjetoAulas.Business.Models
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        /* EF Relational */
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        /* EF Relational */
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
