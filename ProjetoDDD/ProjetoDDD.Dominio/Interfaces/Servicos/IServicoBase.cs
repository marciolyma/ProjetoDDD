using System.Collections.Generic;

namespace ProjetoDDD.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Incluir(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(TEntity obj);
        IEnumerable<TEntity> SelecionarTodos(string order);
        TEntity SelecionarPorId(int id);
        void Dispose();
    }
}
