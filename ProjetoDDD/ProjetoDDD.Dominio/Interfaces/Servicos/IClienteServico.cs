using ProjetoDDD.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoDDD.Dominio.Interfaces.Servicos
{
    public interface IClienteServico: IServicoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
