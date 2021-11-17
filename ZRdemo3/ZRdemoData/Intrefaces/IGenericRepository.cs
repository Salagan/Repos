using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Intrefaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T> FindAsync(params Expression<Func<T, bool>>[] expressions);

        void Add(T entity);

        void AddRange(IEnumerable<T> enities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> enities);
    }
}
