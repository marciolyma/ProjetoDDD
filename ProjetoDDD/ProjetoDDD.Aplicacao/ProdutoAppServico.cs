using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System;

namespace ProjetoDDD.Aplicacao
{
    public class ProdutoAppServico : AppServicoBase<Produto>, IProdutoAppServico
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoAppServico(IProdutoServico produtoServico)
            :base(produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public IEnumerable<Produto> BuscaProdutoCliente(int id)
        {
            return _produtoServico.BuscaProdutoCliente(id);
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoServico.BuscarPorNome(nome);
        }
    }
}
