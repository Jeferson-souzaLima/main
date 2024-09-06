using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAulas.Business.Models;

namespace ProjetoAulas.Business.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<Categoria> ObterCategoriaProdutos(Guid id);
    }
}
