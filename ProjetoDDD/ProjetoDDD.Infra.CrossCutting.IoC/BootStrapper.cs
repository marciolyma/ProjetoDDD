using ProjetoDDD.Aplicacao;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using ProjetoDDD.Dominio.Interfaces.Repositorio;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using ProjetoDDD.Dominio.Servicos;
using ProjetoDDD.Infra.Dados.Repositorio;
using SimpleInjector;

namespace ProjetoDDD.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegistraServicos(Container container)
        {
            container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>),Lifestyle.Scoped);
            container.Register<IClienteRepositorio, ClienteRepositorio>(Lifestyle.Scoped);
            container.Register<IProdutoRepositorio, ProdutoRepositorio>(Lifestyle.Scoped);

            container.Register(typeof(IServicoBase<>), typeof(ServicoBase<>), Lifestyle.Scoped);
            container.Register<IClienteServico, ClienteServico>(Lifestyle.Scoped);
            container.Register<IProdutoServico, ProdutoServico>(Lifestyle.Scoped);

            container.Register(typeof(IAppServicoBase<>), typeof(AppServicoBase<>), Lifestyle.Scoped);
            container.Register<IClienteAppServico, ClienteAppServico>(Lifestyle.Scoped);
            container.Register<IProdutoAppServico, ProdutoAppServico>(Lifestyle.Scoped);

        }
    }
}
