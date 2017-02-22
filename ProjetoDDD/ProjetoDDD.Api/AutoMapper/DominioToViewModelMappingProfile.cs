using AutoMapper;
using ProjetoDDD.Api.ViewModel;
using ProjetoDDD.Dominio.Entidades;

namespace ProjetoDDD.Api.AutoMapper
{
    public class DominioToViewModelMappingProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}