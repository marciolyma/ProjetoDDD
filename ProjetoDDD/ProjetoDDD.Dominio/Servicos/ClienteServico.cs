using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Repositorio;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDDD.Dominio.Servicos
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
            :base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}
