using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    public class FornecedorEnderecoRepository : BaseRepository<FornecedorEndereco>, IFornecedorEnderecoRepository
    {
        public FornecedorEnderecoRepository(AppDbContext context) : base(context) { }
        public async Task<FornecedorEndereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.FornecedoresEndereco.AsNoTracking().FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
