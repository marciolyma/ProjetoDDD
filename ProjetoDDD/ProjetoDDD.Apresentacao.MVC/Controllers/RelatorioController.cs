using AutoMapper;
using PagedList;
using ProjetoDDD.Apresentacao.MVC.ViewModels;
using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDDD.Apresentacao.MVC.Controllers
{
    [Authorize]
    public class RelatorioController : Controller
    {
        private IClienteAppServico _clienteApp;
        private IProdutoAppServico _produtoApp;

        public RelatorioController(IClienteAppServico clienteApp, IProdutoAppServico produtoApp)
        {
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
        }

        // GET: Relatorios
        public ActionResult ListagemCliente(int? pagina, Boolean? gerarPDF)
        {
            var listagemClientes = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.SelecionarTodos("Nome"));

            if (gerarPDF != true)
            {
                //Definindo a paginação
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);
                return View(listagemClientes.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemCliente",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = listagemClientes.ToPagedList(paginaNumero, listagemClientes.Count())
                };
                return pdf;
            }
        }

        // GET: Relatorios
        public ActionResult ListagemProduto(int? pagina, Boolean? gerarPDF)
        {
            var listagemProdutos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.SelecionarTodos("Nome"));

            if (gerarPDF != true)
            {
                //Definindo a paginação
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);
                return View(listagemProdutos.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemProduto",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = listagemProdutos.ToPagedList(paginaNumero, listagemProdutos.Count())
                };
                return pdf;
            }
        }
    }
}