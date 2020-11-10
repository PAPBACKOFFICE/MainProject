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
        TEntity Find<TEntity>(int id) where TEntity : class;
        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;
        List<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;
        TEntity Create<TEntity>(TEntity entityObj) where TEntity : class;
        void Update<TEntity>(TEntity entityObj) where TEntity : class;
        void Delete<TEntity>(TEntity entityObj) where TEntity : class;
        void Detach<TEntity>(TEntity entityObj) where TEntity : class;
        TEntity Reload<TEntity>(TEntity entityObj) where TEntity : class;
    }
}
