using App.BusinessLayer.Entities;
using App.BusinessLayer.Interfaces.Repositories;
using App.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.DataLayer.Repositories
{
    public abstract class Repository<TEntity>(MsSQLServerContext msSQLServer) : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MsSQLServerContext Db = msSQLServer;
        protected readonly DbSet<TEntity> DbSet = msSQLServer.Set<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> SearchFunction(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new() { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
