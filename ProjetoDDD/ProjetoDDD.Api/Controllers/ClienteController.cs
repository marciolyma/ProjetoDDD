using AutoMapper;
using ProjetoDDD.Api.ViewModel;
using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoDDD.Api.Controllers
{
    [RoutePrefix("/api/cliente")]
    public class ClienteController : ApiController
    {
        private IClienteAppServico _clienteApp;
        private IProdutoAppServico _produtoApp;

        public ClienteController(IClienteAppServico clienteApp, IProdutoAppServico produtoApp)
        {
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
        }

        // GET: api/Cliente
        public HttpResponseMessage GetCliente()
        {
            var result = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.SelecionarTodos("Nome"));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Cliente/5
        public HttpResponseMessage GetCliente(int id)
        {
            var produto = _produtoApp.BuscaProdutoCliente(id);
            var result = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produto);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    //    // POST: api/Cliente
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT: api/Cliente/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE: api/Cliente/5
    //    public void Delete(int id)
    //    {
    //    }
    }
}
