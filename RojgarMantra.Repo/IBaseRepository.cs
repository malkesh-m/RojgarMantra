using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RojgarMantra.Data.Entities;

namespace RojgarMantra.Repo
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<List<T>> GetAll();

        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);

        Task<List<T>> SearchBy(Expression<Func<T, bool>> searchBy, params Expression<Func<T, object>>[] includes);

        Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<bool> Update(T entity);

        Task<bool> Delete(Expression<Func<T, bool>> identity, params Expression<Func<T, object>>[] includes);

        Task<bool> Delete(T entity);

        Task<T> Get(int id);

        Task<bool> Delete(int id);

        Task<List<T>> GetPage(int pageNo, int pageSize);

        Task<int> Count();
        Task<bool> DeleteRange(IEnumerable<T> entities);
        IQueryable<T> Query();
        IQueryable<T> GetPageQuery(int pageNo, int pageSize);
    }
}