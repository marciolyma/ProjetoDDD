using ProjetoDDD.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoDDD.Dominio.Interfaces.Aplicacao
{
    public interface IClienteAppServico: IAppServicoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
