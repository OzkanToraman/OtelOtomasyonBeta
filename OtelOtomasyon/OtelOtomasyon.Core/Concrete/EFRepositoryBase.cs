using OtelOtomasyon.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OtelOtomasyon.DAL.Entities;

namespace OtelOtomasyon.Core.Concrete
{
    public class EFRepositoryBase<T, TContext> : IRepository<T>, IDisposable
        where T : BaseEntity, new()
        where TContext : DbContext
    {
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;

        public EFRepositoryBase(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_disposed == false)
                {
                    Dispose();
                    _disposed = true;
                }
            }
        }

        public void Dispose()
        {

            _dbContext.Dispose();

            GC.SuppressFinalize(this);

        }

        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsEnumerable<T>();
        }

        public IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsQueryable<T>();
        }

    }
}
