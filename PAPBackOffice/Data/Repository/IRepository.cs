using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Data.Repository
{
    public interface IRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class;
        Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;
        Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;
        Task<TEntity> Create<TEntity>(TEntity entityObj) where TEntity : class;
        Task Update<TEntity>(TEntity entityObj) where TEntity : class;
        Task Delete<TEntity>(TEntity entityObj) where TEntity : class;
        Task Detach<TEntity>(TEntity entityObj) where TEntity : class;
        Task<TEntity> Reload<TEntity>(TEntity entityObj) where TEntity : class;
    }
}
