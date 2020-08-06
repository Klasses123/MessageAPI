using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MessageAPI.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Create(T item);
        Task<T> CreateAsync(T item);
        void Save();
        Task SaveAsync();
    }
}
