using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PAPBackOffice.Data.Repository
{
    public class Repository : IRepository
    {
        public readonly string EntityName;

        public AppDatabaseContext dbContext;


        public bool IsDisposed;

        public Repository(AppDatabaseContext AppDataContext)
        {
            dbContext = AppDataContext;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return dbContext.Set<TEntity>().AsQueryable();

        }

        public async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "Id");
            var property = Expression.Property(parameter, "Id");
            var condition = Expression.Equal(Expression.Convert(property, typeof(int)), Expression.Constant(id));
            var predicate = Expression.Lambda<Func<TEntity, bool>>(condition, parameter);

            return await FindAsync(predicate);
        }

        public async Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            if (predicate != null)
                return await dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();

            return await dbContext.Set<TEntity>().FirstOrDefaultAsync();

        }

        public async Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            if (predicate != null)
                return await dbContext.Set<TEntity>().Where(predicate).ToListAsync();

            return await dbContext.Set<TEntity>().ToListAsync();

        }

        public async Task<TEntity> Create<TEntity>(TEntity entityObj) where TEntity : class
        {
            if (entityObj == null) throw new NullReferenceException($"Não foi possível criar {EntityName}. O objecto está nulo.");

            var recordId = Convert.ToInt32(entityObj.GetType().GetProperty("Id").GetValue(entityObj));
            if (recordId != 0)
                throw new ArgumentException($"Não foi possível criar {EntityName}. O ID não é 0.");

            dbContext.Set<TEntity>().Add(entityObj);

            await SaveChangesAsync();


            return entityObj;
        }

        public async Task Update<TEntity>(TEntity entityObj) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task Delete<TEntity>(TEntity entityObj) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task Detach<TEntity>(TEntity entityObj) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Reload<TEntity>(TEntity entityObj) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var dateNow = DateTime.Now;

            foreach (var entry in dbContext.ChangeTracker.Entries()
                                            .Where(e => e.State == EntityState.Added ||
                                                    e.State == EntityState.Modified ||
                                                    e.State == EntityState.Deleted))
            {
                if (entry.State == EntityState.Added)
                {
                    var createdBy = entry.Entity.GetType().GetProperty("CriadoPor");
                    if (createdBy != null)
                    {
                        var v = (int?)createdBy.GetValue(entry.Entity);
                        if (!v.HasValue || v.Value == 0)
                            throw new UnauthorizedAccessException();
                    }

                    var createdOn = entry.Entity.GetType().GetProperty("CriadoEm");
                    if (createdOn != null)
                    {
                        var v = (DateTime)createdOn.GetValue(entry.Entity);

                        createdOn.SetValue(entry.Entity, dateNow, null);
                    }
                }

                var modifiedBy = entry.Entity.GetType().GetProperty("AlteradoPor");
                if (modifiedBy != null)
                {
                    var v = (int?)modifiedBy.GetValue(entry.Entity);
                    if (!v.HasValue || v.Value == 0)
                        throw new UnauthorizedAccessException();
                }

                var modifiedOn = entry.Entity.GetType().GetProperty("AlteradoEm");
                if (modifiedOn != null)
                {
                    var v = (DateTime?)modifiedOn.GetValue(entry.Entity);
                    if (!v.HasValue)
                        modifiedOn.SetValue(entry.Entity, dateNow, null);
                }

                // Audit entry
            }

            var result = await dbContext.SaveChangesAsync(cancellationToken);

            return Convert.ToBoolean(result);
        }
    }
}
