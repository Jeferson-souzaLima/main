using ProjetoAulas.Business.Interfaces;
using ProjetoAulas.Data.Contexts;
using ProjetoAulas.Data.Repositories;

namespace ProjetoAulas.App.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
           services.AddScoped<AppDbContext>();
           services.AddScoped<ICategoriaRepository, CategoriaRepository>();
           services.AddScoped<IFornecedorRepository, FornecedorRepository>();
           services.AddScoped<IProdutoRepository, ProdutoRepository>();
           services.AddScoped<IFornecedorEnderecoRepository, FornecedorEnderecoRepository>();

            return services;
        }
    }
}
