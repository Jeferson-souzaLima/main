using ProjetoAulas.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAulas.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorEndereco> FornecedoresEndereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar os campos do tipo string, caso não sejam mapeados
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //Informar qual será o contexto utilizado
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //Configurar para que não haja exclusão em cascata no banco de dados
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
