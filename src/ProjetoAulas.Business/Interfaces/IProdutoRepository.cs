using ProjetoAulas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAulas.Business.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<Produto> ObterProdutosFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid ForncedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<IEnumerable<Produto>> ObterProdutosPorCategoria(Guid CategoriaId);
    }
}
