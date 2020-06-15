using Domain.Entities.Models;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CTX db;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(CTX _db)
        {
            db = _db;
            dbSet = _db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get_AllWay(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Get_ById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> Get_All()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task UpDate(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            dbSet.Remove(new TEntity { Id = id});
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db? .Dispose(); ;
        }
    }
}
