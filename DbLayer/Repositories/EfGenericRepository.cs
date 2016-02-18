using DbLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories
{
    public class EfGenericRepository<T> : EfRepository, IGenericRepository<T> where T : class
    {
        public virtual T Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public virtual T Update(T entity)
        {
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public virtual T Delete(T entity)
        {
            var toDelete = _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(toDelete);
            return toDelete;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<TRes> GetAll<TRes>() where TRes : class
        {
            return _context.Set<TRes>();
        }
    }
}
