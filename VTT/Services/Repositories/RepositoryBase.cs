using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VTT.Models.Entities;
using VTT.Data;

namespace VTT.Services.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    private readonly AppDbContext _AppDbContext;

    public RepositoryBase(AppDbContext AppDbContext)
    {
        _AppDbContext = AppDbContext;
    }

    public async virtual Task<bool> ExistsAsync(long id)
    {
        var entity = await FindAsync(e => e.id == id);

        bool entityExists = entity != null;
        return entityExists;
    }

    public async virtual Task<TEntity> GetAsync(long id)
    {
        var entity = await _AppDbContext.FindAsync<TEntity>(id);

        return entity;
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _AppDbContext
            .Set<TEntity>()
            .ToListAsync();

        return entities;
    }

    public async virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await _AppDbContext
            .Set<TEntity>()
            .AsQueryable()
            .Where(predicate)
            .ToListAsync();

        return entities;
    }

    public async virtual Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntityEntry = await _AppDbContext.AddAsync(entity);

        var addedEntity = addedEntityEntry.Entity;

        await _AppDbContext.SaveChangesAsync();

        return addedEntity;
    }

    public async virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _AppDbContext.AddRangeAsync(entities);

        await _AppDbContext.SaveChangesAsync();
    }

    public async virtual Task RemoveAsync(TEntity entity)
    {
        _AppDbContext.Remove(entity);

        await _AppDbContext.SaveChangesAsync();
    }

    public async virtual Task SaveChangesAsync()
    {
        await _AppDbContext.SaveChangesAsync();
    }
}
