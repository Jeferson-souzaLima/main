using AutoMapper;
using ProjetoAulas.App.ViewModels;
using ProjetoAulas.Business.Models;

namespace ProjetoAulas.App.AutoMapper
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        { 
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<FornecedorEndereco, FornecedorEnderecoViewModel>().ReverseMap();
        }


    }
}
