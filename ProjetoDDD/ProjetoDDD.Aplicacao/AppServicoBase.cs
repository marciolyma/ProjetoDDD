using ProjetoDDD.Dominio.Interfaces.Aplicacao;
using ProjetoDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoDDD.Aplicacao
{
    public class AppServicoBase<TEntity> : IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private IServicoBase<TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Alterar(TEntity obj)
        {
            _servicoBase.Alterar(obj);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }

        public void Excluir(TEntity obj)
        {
            _servicoBase.Excluir(obj);
        }

        public void Incluir(TEntity obj)
        {
            _servicoBase.Incluir(obj);
        }

        public TEntity SelecionarPorId(int id)
        {
            return _servicoBase.SelecionarPorId(id);
        }

        public IEnumerable<TEntity> SelecionarTodos(string order)
        {
            return _servicoBase.SelecionarTodos(order);
        }
    }
}
