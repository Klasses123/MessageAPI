using MessageAPI.Database;
using MessageAPI.Interfaces;
using MessageAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MessageAPI.Repositories
{
    /// <summary>
    /// Generic repository for interacting with database types
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : BaseRepository<TEntity> where TEntity : class, IDataModel
    {
        protected override DbSet<TEntity> DbEntities { get; }
        protected DbMainContext Context { get; }

        public GenericRepository(DbMainContext context) : base(context)
        {
            DbEntities = context.Set<TEntity>();
            Context = context;
        }

        public override TEntity Create(TEntity item)
        {
            return DbEntities.Add(item).Entity;
        }

        public override async Task<TEntity> CreateAsync(TEntity item)
        {
            return (await DbEntities.AddAsync(item)).Entity;
        }

        public override IQueryable<TEntity> Get()
        {
            return DbEntities.AsNoTracking();
        }

        public override IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbEntities.Where(predicate).AsNoTracking();
        }
    }
}
