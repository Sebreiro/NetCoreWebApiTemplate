using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.NetCore.Template.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> DbSet { get; }
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Attach(TEntity entity);
        void Detach(TEntity entity);
        TEntity Get(object id);
        ValueTask<TEntity> GetAsync(object id);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Filtered(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] include);
    }
}