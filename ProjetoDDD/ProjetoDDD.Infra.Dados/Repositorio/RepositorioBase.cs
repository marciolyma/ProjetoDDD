using ProjetoDDD.Dominio.Interfaces.Repositorio;
using ProjetoDDD.Dominio.Servicos;
using ProjetoDDD.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoDDD.Infra.Dados.Repositorio
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected ProjetoDbContext _dB = new ProjetoDbContext();

        public void Alterar(TEntity obj)
        {
            _dB.Entry(obj).State = EntityState.Modified;
            _dB.SaveChanges();
        }

        public void Dispose()
        {
            _dB.Dispose();
        }

        public void Excluir(TEntity obj)
        {
            _dB.Entry(obj).State = EntityState.Deleted;
            _dB.SaveChanges();
        }

        public void Incluir(TEntity obj)
        {
            _dB.Set<TEntity>().Add(obj);
            _dB.SaveChanges();
        }

        public TEntity SelecionarPorId(int id)
        {
            return _dB.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> SelecionarTodos(string order)
        {
            return _dB.Set<TEntity>().OrderBy(OrderEntity.GetExpression<TEntity>(order)).ToList();
        }
    }
}
