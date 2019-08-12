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

        public GenericRepository(SmartGroceryDataContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
            
        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
