using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solution.CrossCutting.Utils
{
    public interface IRelationalRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> Queryable { get; }

        T FirstOrDefault(params Expression<Func<T, object>>[] include);

        T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where);

        TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

        Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);

        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

        T LastOrDefault(params Expression<Func<T, object>>[] include);

        T LastOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        TResult LastOrDefault<TResult>(Expression<Func<T, bool>> where);

        TResult LastOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

        Task<T> LastOrDefaultAsync(params Expression<Func<T, object>>[] include);

        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        Task<TResult> LastOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);

        Task<TResult> LastOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

        IEnumerable<T> List(params Expression<Func<T, object>>[] include);

        IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        PagedList<T> List(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

        PagedList<T> List(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include);

        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where);

        TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);

        Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);
    }
}
