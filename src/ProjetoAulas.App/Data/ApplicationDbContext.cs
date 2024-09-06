using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoAulas.App.ViewModels;

namespace ProjetoAulas.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoAulas.App.ViewModels.CategoriaViewModel> CategoriaViewModel { get; set; } = default!;
        public DbSet<ProjetoAulas.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
        public DbSet<ProjetoAulas.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
       
    }
}
