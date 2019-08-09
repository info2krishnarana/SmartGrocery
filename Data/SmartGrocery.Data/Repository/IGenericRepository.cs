using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrocery.Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(object obj);
        T GetById(object id);
        object Insert(T obj);
        object Update(T obj);
        object Delete(object id);
        object Save();
        bool Exist(object obj);
    }
}
