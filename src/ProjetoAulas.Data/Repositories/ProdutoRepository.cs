using Microsoft.EntityFrameworkCore;
using ProjetoAulas.Business.Interfaces;
using ProjetoAulas.Business.Models;
using ProjetoAulas.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAulas.Data.Repositories
{

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public async Task<Produto> ObterProdutosFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor).Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().
                                     Include(p => p.Fornecedor).
                                     Include(p => p.Categoria).
                                     OrderBy(p => p.Nome).
                                     ToListAsync();
        }
        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(Guid categoriaId)
        {
            return await Buscar(p => p.CategoriaId == categoriaId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
