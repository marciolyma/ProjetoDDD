using AutoMapper;
using ProjetoDDD.Api.ViewModel;
using ProjetoDDD.Dominio.Entidades;

namespace ProjetoDDD.Api.AutoMapper
{
    public class ViewModelToDominioMappingProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}