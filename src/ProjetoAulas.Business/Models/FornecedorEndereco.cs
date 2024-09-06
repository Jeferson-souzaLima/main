namespace ProjetoAulas.Business.Models
{
    public class FornecedorEndereco : BaseEntity
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        /* EF Relational */
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
