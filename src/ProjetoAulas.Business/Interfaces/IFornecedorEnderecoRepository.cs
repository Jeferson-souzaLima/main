using ProjetoAulas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAulas.Business.Interfaces
{
    public interface IFornecedorEnderecoRepository : IBaseRepository<FornecedorEndereco>
    {
        Task<FornecedorEndereco> ObterEnderecoPorFornecedor(Guid ForncedorId);
    }
}
