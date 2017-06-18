﻿using App.Core.Dal;
using App.Core.Entites;
using App.WebInfo.Busipubness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.WebInfo.Business.Concrete
{
    public class ManagerBase<TManger, TEntity> : IServiceBase<TEntity>
        where TManger : class, IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private TManger _manager;
        public ManagerBase(TManger manager)
        {
            _manager = manager;
        }
        public async Task Add(TEntity entity)
        {
            await _manager.Add(entity);
        }

        public async Task<long> Count()
        {
            return await _manager.Count();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _manager.Get(filter);
        }
        public async Task<List<TEntity>> GetList()
        {
            return await _manager.GetList(null, null);
        }
        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, bool>>[] include)
        {
            return await _manager.GetList(filter, include);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderProperty = null, int pageNumber = 1, int pageSize = 10, bool isAscendingOrder = true, params Expression<Func<TEntity, bool>>[] include)
        {
            return await _manager.GetList(filter, orderProperty, pageNumber, pageSize, isAscendingOrder, include);
        }

        public async Task Update(TEntity entity)
        {
            await _manager.Update(entity);
        }
    }
}
