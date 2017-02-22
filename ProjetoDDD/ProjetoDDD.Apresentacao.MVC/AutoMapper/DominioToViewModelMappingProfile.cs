using AutoMapper;
using ProjetoDDD.Apresentacao.MVC.ViewModels;
using ProjetoDDD.Dominio.Entidades;

namespace ProjetoDDD.Apresentacao.MVC.AutoMapper
{
    public class DominioToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}