using ProjetoDDD.Dominio.Entidades;
using ProjetoDDD.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ProjetoDDD.Infra.Dados.Repositorio
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public IEnumerable<Produto> BuscaProdutoCliente(int id)
        {
            return _dB.Produtos.OrderBy(p => p.Nome).Where(p => p.ClienteId == id);
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _dB.Produtos.OrderBy(p => p.Nome).Where(p => p.Nome.Contains(nome));
        }
    }
}
