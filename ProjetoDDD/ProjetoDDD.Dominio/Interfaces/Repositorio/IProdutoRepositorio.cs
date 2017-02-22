using ProjetoDDD.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoDDD.Dominio.Interfaces.Repositorio
{
    public interface IProdutoRepositorio: IRepositorioBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscaProdutoCliente(int id);
    }
}
