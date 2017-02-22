using AutoMapper;
using PagedList;
using ProjetoDDD.Apresentacao.MVC.ViewModels;
using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoDDD.Apresentacao.MVC.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppServico _produtoApp;
        private readonly IClienteAppServico _clienteApp;

        public ProdutoController(IProdutoAppServico produtoApp, IClienteAppServico clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        // GET: Produto
        public ActionResult Index(int? pagina)
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.SelecionarTodos("Nome"));
            //Definindo a paginação
            int paginaQdteRegistros = 10;
            int paginaNumeroNavegacao = (pagina ?? 1);
            return View(produtoViewModel.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
        }

        //GET: Produto/BuscarPorNome/id
        public ActionResult BuscarPorNome(string id, int? pagina)
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.SelecionarTodos("Nome"));
            int paginaQdteRegistros = 10;
            int paginaNumeroNavegacao = (pagina ?? 1);
            if (!string.IsNullOrEmpty(id))
                produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.BuscarPorNome(id));
            return PartialView("_ListaProdutosPartial", produtoViewModel.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.SelecionarPorId(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return PartialView("_Details", produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.SelecionarTodos("Nome"), "ClienteId", "FullNome");
            return PartialView("_Create");
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDominio = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Incluir(produtoDominio);
                ViewBag.ClienteId = new SelectList(_clienteApp.SelecionarTodos("Nome"), "ClienteId", "FullNome");
                // return Json(new { success = true});
                ModelState.Clear();
                return PartialView("_Create");

            }
            ViewBag.ClienteId = new SelectList(_clienteApp.SelecionarTodos("Nome"), "ClienteId", "FullNome", produto.ClienteId);
            return PartialView("_Create", produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.SelecionarPorId(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            ViewBag.ClienteId = new SelectList(_clienteApp.SelecionarTodos("Nome"), "ClienteId", "Nome", produto.ClienteId);
            return PartialView("_Edit", produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDominio = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Alterar(produtoDominio);
                return Json(new { success = true });
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.SelecionarTodos("Nome"), "ClienteId", "Nome", produto.ClienteId);
            return PartialView("_Edit", produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.SelecionarPorId(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            ViewBag.ClienteId = new SelectList(_clienteApp.SelecionarTodos("Nome"), "ClienteId", "Nome", produto.ClienteId);
            return PartialView("_Delete", produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var produtoDominio = _produtoApp.SelecionarPorId(id);
                _produtoApp.Excluir(produtoDominio);
            }
            return Json(new { success = true });
        }
    }
}