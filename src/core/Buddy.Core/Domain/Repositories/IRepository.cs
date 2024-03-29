﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Buddy.Domain.Entities;

namespace Buddy.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    #region Insert

    void Insert(TEntity entity);

    #endregion

    #region Update

    void Update(TEntity entity);

    #endregion

    #region Select

    IQueryable<TEntity> GetAll();

    List<TEntity> GetAllList();

    List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

    TEntity Get(int id);

    TEntity FirstOrDefault(int id);

    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

    #endregion

    #region Delete

    void Delete(int id);

    void Delete(TEntity entity);

    void Delete(Expression<Func<TEntity, bool>> predicate);

    #endregion

    #region Aggregates

    int Count();

    int Count(Expression<Func<TEntity, bool>> predicate);

    #endregion
}