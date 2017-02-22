using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace ProjetoDDD.Aplicacao
{
    public class ClienteAppServico : AppServicoBase<Cliente>, IClienteAppServico
    {
        private readonly IClienteServico _clienteServico;

        public ClienteAppServico(IClienteServico clienteServicco)
            : base(clienteServicco)
        {
            _clienteServico = clienteServicco;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
            return _clienteServico.ObterClientesEspeciais(SelecionarTodos("Nome"));
        }
    }
}
