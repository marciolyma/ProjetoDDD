using AutoMapper;
using ProjetoDDD.Apresentacao.MVC.ViewModels;
using ProjetoDDD.Dominio.Entidades;

namespace ProjetoDDD.Apresentacao.MVC.AutoMapper
{
    public class ViewModelToDominioMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}