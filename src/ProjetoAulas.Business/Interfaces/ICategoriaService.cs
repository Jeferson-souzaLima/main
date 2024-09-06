using ProjetoAulas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAulas.Business.Interfaces
{
    public interface ICategoriaService : IDisposable
    {
        Task Adicionar(Categoria categoria);
        Task Alterar(Categoria categoria);
        Task Remover(Guid id);
        Task ObterCategoriaProdutos(Guid id);
    }
}
