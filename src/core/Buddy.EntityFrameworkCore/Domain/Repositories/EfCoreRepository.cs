using System.Collections.Generic;
using System.Linq;
using Buddy.Domain.Entities;
using Buddy.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Buddy.Domain.Repositories;

public class EfCoreRepository<TEntity> : BuddyRepositoryBase<TEntity> where TEntity : Entity
{
    private readonly BuddyDbContext _dbContext;

    public EfCoreRepository(BuddyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private void AttachIfNot(TEntity entity)
    {
        var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
        if (entry != null)
        {
            return;
        }

        _dbContext.Set<TEntity>().Attach(entity);
    }

    private TEntity GetFromChangeTrackerOrNull(int id)
    {
        var entry = _dbContext.ChangeTracker.Entries()
            .FirstOrDefault(
                ent =>
                    ent.Entity is TEntity entity &&
                    EqualityComparer<int>.Default.Equals(id, entity.Id)
            );

        return entry?.Entity as TEntity;
    }

    public override TEntity Insert(TEntity entity)
    {
        var entityObj = _dbContext.Set<TEntity>().Add(entity).Entity;
        
        _dbContext.SaveChanges();

        return entityObj;
    }

    public override TEntity Update(TEntity entity)
    {
        AttachIfNot(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public override IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>();
    }

    public override void Delete(TEntity entity)
    {
        AttachIfNot(entity);
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public override void Delete(int id)
    {
        var entity = GetFromChangeTrackerOrNull(id);
        if (entity != null)
        {
            Delete(entity);
            return;
        }

        entity = FirstOrDefault(id);
        if (entity == null)
        {
            //Could not found the entity, do nothing.
            return;
        }

        Delete(entity);
    }
}