using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RojgarMantra.Repo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbContext _ctx;

        public BaseRepository(DbContext context)
        {
            _ctx = context;
        }

        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                _ctx.Set<T>().Add(entity);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var result = _ctx.Set<T>().Where(i => true);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.ToListAsync();
        }


        public virtual async Task<List<T>> SearchBy(Expression<Func<T, bool>> searchBy, params Expression<Func<T, object>>[] includes)
        {
            var result = _ctx.Set<T>().Where(searchBy);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.ToListAsync();
        }

        /// <summary>
        /// Finds by predicate.
        /// http://appetere.com/post/passing-include-statements-into-a-repository
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public virtual async Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var result = _ctx.Set<T>().Where(predicate);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                _ctx.Set<T>().Attach(entity);
                _ctx.Entry(entity).State = EntityState.Modified;

                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual async Task<bool> Delete(Expression<Func<T, bool>> identity, params Expression<Func<T, object>>[] includes)
        {
            var results = _ctx.Set<T>().Where(identity);

            foreach (var includeExpression in includes)
                results = results.Include(includeExpression);
            try
            {
                _ctx.Set<T>().RemoveRange(results);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual async Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            _ctx.Set<T>().RemoveRange(entities);
            return await Task.FromResult(true);
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            return await Task.FromResult(true);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
            //return await Task.FromResult(true);
        }

        public virtual async Task<bool> Delete(int id)
        {
            T entity = await Get(id);
            return await Delete(entity);
        }

        public virtual async Task<List<T>> GetPage(int pageNo, int pageSize)
        {
            if(pageNo==1)
            {
                return await _ctx.Set<T>().Take(pageSize).ToListAsync();
            }
            else
            {
                return await _ctx.Set<T>().Skip((pageNo-1) * pageSize).Take(pageSize).ToListAsync();
            }
        }

        public virtual IQueryable<T> GetPageQuery(int pageNo, int pageSize)
        {
            if (pageNo == 1)
            {
                return _ctx.Set<T>().Take(pageSize);
            }
            else
            {
                return _ctx.Set<T>().Skip((pageNo - 1) * pageSize).Take(pageSize);
            }
        }

        public virtual async Task<int> Count()
        {
            var count = _ctx.Set<T>().Count();
            return await Task.FromResult(count);
        }

        public IQueryable<T> Query()
        {
            return _ctx.Set<T>().AsQueryable();
        }
    }

}
