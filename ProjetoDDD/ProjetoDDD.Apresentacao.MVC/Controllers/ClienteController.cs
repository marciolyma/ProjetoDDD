using AutoMapper;
using PagedList;
using ProjetoDDD.Apresentacao.MVC.Filters;
using ProjetoDDD.Apresentacao.MVC.ViewModels;
using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoDDD.Apresentacao.MVC.Controllers
{
    [ClaimsAuthorize("Usuario", "True")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppServico _clienteApp;

        public ClienteController(IClienteAppServico clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: Cliente
        public ActionResult Index(int? pagina)
        {

            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.SelecionarTodos("Nome"));
            
            //Definindo a paginação
            int paginaQdteRegistros = 10;
            int paginaNumeroNavegacao = (pagina ?? 1);
            return View(clienteViewModel.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
        }

        //GET: Cliente/ClienteEspecial
        public ActionResult ClienteEspecial(int? pagina)
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais(_clienteApp.SelecionarTodos("Nome")));
            //Definindo a paginação
            int paginaQdteRegistros = 10;
            int paginaNumeroNavegacao = (pagina ?? 1);
            return PartialView("_ListaClientePartial", clienteViewModel.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
        }

        public ActionResult RetornarTodos(int? pagina)
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.SelecionarTodos("Nome"));
            //Definindo a paginação
            int paginaQdteRegistros = 10;
            int paginaNumeroNavegacao = (pagina ?? 1);
            return PartialView("_ListaClientePartial", clienteViewModel.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
        }

        public ActionResult Observacao(int id)
        {
            var cliente = _clienteApp.SelecionarPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Observacao(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDominio = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Alterar(clienteDominio);
            }
            return RedirectToAction("Index");
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.SelecionarPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return PartialView("_Details", clienteViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDominio = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Incluir(clienteDominio);
                return Json(new { success = true });
            }
            return PartialView("_Create", cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.SelecionarPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return PartialView("_Edit", clienteViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDominio = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Alterar(clienteDominio);
                return Json(new { success = true });
            }
            return PartialView("_Edit", cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.SelecionarPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return PartialView("_Delete", clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var cliente = _clienteApp.SelecionarPorId(id);
                if (ModelState.IsValid)
                {
                    _clienteApp.Excluir(cliente);
                }
            }
            catch (Exception)
            {
                return PartialView("_ErrorModal");
            }
            return Json(new { success = true });
            //        return RedirectToAction("Index");
        }
    }
}