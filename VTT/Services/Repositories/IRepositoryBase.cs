﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VTT.Models.Entities;
using VTT.Data;

namespace VTT.Services.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<bool> ExistsAsync(long id);

        Task<TEntity> GetAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        Task SaveChangesAsync();
    }
}
