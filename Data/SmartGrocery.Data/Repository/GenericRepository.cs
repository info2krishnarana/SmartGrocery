using SmartGrocery.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrocery.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private SmartGroceryDataContext _context = null;
        private DbSet<T> _dbSet = null;

        public GenericRepository()
        {
            this._context = new SmartGroceryDataContext();
            this._dbSet = _context.Set<T>();
        }

        public object Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(object obj)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public object Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public object Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
