using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Repositorio;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System;

namespace ProjetoDDD.Dominio.Servicos
{
    public class ProdutoServico : ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
            :base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> BuscaProdutoCliente(int id)
        {
            return _produtoRepositorio.BuscaProdutoCliente(id);
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepositorio.BuscarPorNome(nome);
        }
    }
}
