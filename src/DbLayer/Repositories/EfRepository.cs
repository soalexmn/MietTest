using DbLayer.Contexts;
using DbLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories
{
    public class EfRepository : IRepository
    {
        protected MainContext _context;


        public EfRepository()
        {
            _context = new MainContext();
#if DEBUG
            _context.Database.Log = (str) => System.Diagnostics.Debug.WriteLine(str);
#endif
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public MainContext Context
        {
            get { return _context; }
        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }


        public void SetContext(MainContext context)
        {
            _context = context;
        }
    }
}
