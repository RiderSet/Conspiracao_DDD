﻿using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void UpDate(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
