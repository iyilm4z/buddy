using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Buddy.Domain.Entities;

namespace Buddy.Domain.Repositories;

public abstract class BuddyRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    #region Insert

    public abstract TEntity Insert(TEntity entity);

    #endregion

    #region Update

    public abstract TEntity Update(TEntity entity);
    public abstract Task<TEntity> UpdateAsync(TEntity entity);

    #endregion

    #region Select

    public abstract IQueryable<TEntity> GetAll();

    public virtual List<TEntity> GetAllList()
    {
        return GetAll().ToList();
    }

    public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
    {
        return GetAll().Where(predicate).ToList();
    }

    public virtual TEntity Get(int id)
    {
        var entity = FirstOrDefault(id);
        if (entity == null)
        {
            throw new ApplicationException($"Entity Not Found - type:{typeof(TEntity)}, id:{id}");
        }

        return entity;
    }

    public virtual TEntity FirstOrDefault(int id)
    {
        return GetAll().FirstOrDefault(x => x.Id == id);
    }

    public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return GetAll().FirstOrDefault(predicate);
    }

    public abstract Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    #endregion

    #region Delete

    public abstract void Delete(TEntity entity);

    public abstract void Delete(int id);

    public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
    {
        foreach (var entity in GetAllList(predicate))
        {
            Delete(entity);
        }
    }

    #endregion

    #region Aggregates

    public virtual int Count()
    {
        return GetAll().Count();
    }

    public virtual int Count(Expression<Func<TEntity, bool>> predicate)
    {
        return GetAll().Count(predicate);
    }

    #endregion
}