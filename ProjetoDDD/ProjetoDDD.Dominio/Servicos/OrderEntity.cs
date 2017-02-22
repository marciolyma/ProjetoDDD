using System;
using System.Linq.Expressions;

namespace ProjetoDDD.Dominio.Servicos
{
    public class OrderEntity
    {
        public static Func<T, Object> GetExpression<T>(String sortby)
        {
            var param = Expression.Parameter(typeof(T));
            var sortExpression = Expression.Lambda<Func<T, Object>>(Expression.Convert(Expression.Property(param, sortby), typeof(Object)), param);
            return sortExpression.Compile();
        }
    }
}
