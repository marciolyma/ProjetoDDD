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
    [RoutePrefix("/api/Produto")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAppServico _produtoApp;

        public ProdutoController(IProdutoAppServico produtoApp)
        {
            _produtoApp = produtoApp;
        }

        // GET: api/Produto
        public HttpResponseMessage GetProduto()
        {
            var result = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.SelecionarTodos("Nome"));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Produto/5
        public HttpResponseMessage GetProduto(int id)
        {
            var produto = _produtoApp.BuscaProdutoCliente(id);
            var result = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produto);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //[Route("/api/ProdutoCliente")]
        //public HttpResponseMessage GetProdutoCliente(int id)
        //{
        //    var produto = _produtoApp.BuscaProdutoCliente(id);
        //    var result = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produto);
        //    return Request.CreateResponse(HttpStatusCode.OK, result);
        //}

        //// POST: api/Produto
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Produto/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Produto/5
        //public void Delete(int id)
        //{
        //}
    }
}
