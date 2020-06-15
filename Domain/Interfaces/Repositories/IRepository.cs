using System;
using Domain.Entities.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>: IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> Get_ById(Guid id);
        Task<List<TEntity>> Get_All();
        Task UpDate(TEntity entity);
        Task Remove(Guid id);

        Task<IEnumerable<TEntity>> Get_AllWay(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
