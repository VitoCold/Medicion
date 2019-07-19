using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        void Add(T entity);
        T Get(object id);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();

    }
}
