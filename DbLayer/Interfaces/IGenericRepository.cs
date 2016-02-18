using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
    public interface IGenericRepository<T> : IRepository where T : class
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

        IQueryable<T> GetAll();

        IQueryable<TRes> GetAll<TRes>() where TRes : class;

    }
}
