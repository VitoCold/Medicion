using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class GenericRepository<T,C> : IGenericRepository<T>, IDisposable where T : class, new() where C : DbContext, new()
    {
        public C EFContext;

        public void Add(T entity)
        {
            this.EFContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.EFContext.Set<T>().Attach(entity);
            this.EFContext.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            if (this.EFContext.Database.Connection.State
                == System.Data.ConnectionState.Open)
            {
                this.EFContext.Database.Connection.Close();
                this.EFContext.Database.Connection.Dispose();
            }

            this.EFContext.Dispose();

            GC.SuppressFinalize(this);
        }

        public T Get(object id)
        {
            return this.EFContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.EFContext.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            this.EFContext.Set<T>().Attach(entity);
            this.EFContext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
