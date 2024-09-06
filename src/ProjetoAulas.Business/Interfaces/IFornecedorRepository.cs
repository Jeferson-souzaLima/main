using ProjetoAulas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAulas.Business.Interfaces
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorEnderecoProdutos(Guid id);

    }
}