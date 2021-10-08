using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly ZRdemoContext _context;

        public GenericRepository(ZRdemoContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().RemoveRange(entities);
        }
    }
}
