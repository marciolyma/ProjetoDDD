using ProjetoDDD.Dominio.Interfaces.Repositorio;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoDDD.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public void Alterar(TEntity obj)
        {
            _repositorioBase.Alterar(obj);
        }

        public void Dispose()
        {
            _repositorioBase.Dispose();
        }

        public void Excluir(TEntity obj)
        {
            _repositorioBase.Excluir(obj);
        }

        public void Incluir(TEntity obj)
        {
            _repositorioBase.Incluir(obj);
        }

        public TEntity SelecionarPorId(int id)
        {
            return _repositorioBase.SelecionarPorId(id);
        }

        public IEnumerable<TEntity> SelecionarTodos(string order)
        {
            return _repositorioBase.SelecionarTodos(order);
        }
    }
}
