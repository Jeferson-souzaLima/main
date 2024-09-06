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
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorEnderecoProdutos(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco).Include(f => f.Produtos).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
