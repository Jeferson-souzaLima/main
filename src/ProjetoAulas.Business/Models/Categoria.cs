namespace ProjetoAulas.Business.Models
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
