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
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext db) : base(db) { }

        public async Task<Categoria> ObterCategoriaProdutos(Guid id)
        {
            return await Db.Categorias.AsNoTracking().Include(c => c.Produtos).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
