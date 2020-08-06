using MessageAPI.Database;
using MessageAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MessageAPI.Repositories.Abstract
{
    
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IDataModel
    {
        private bool _disposed;
        private DbMainContext DbMainContext { get; }
        protected abstract DbSet<T> DbEntities { get; }

        protected BaseRepository(DbMainContext dbMainContext)
        {
            DbMainContext = dbMainContext;
        }

        public abstract T Create(T item);

        public abstract Task<T> CreateAsync(T item);

        public abstract IQueryable<T> Get();

        public abstract IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        public void Save()
        {
            DbMainContext.SaveChanges();
        }

        public async virtual Task SaveAsync()
        {
            await DbMainContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbMainContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
    
}
