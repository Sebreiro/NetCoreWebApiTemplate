using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.NetCore.Template.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MainContext _context;

        public DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public Repository(MainContext context)
        {
            _context = context;
        }


        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            DbSet.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            DbSet.RemoveRange(entities);
        }

        public void Attach(TEntity entity)
        {
            DbSet.Attach(entity);
        }

        public void Detach(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Detached;
        }

        public TEntity Get(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return DbSet.Find(id);
        }

        public ValueTask<TEntity> GetAsync(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return DbSet.FindAsync(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            var localresult = DbSet.Local.FirstOrDefault(filter.Compile());

            return localresult ?? DbSet.FirstOrDefault(filter);
        }

        public IQueryable<TEntity> Filtered(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            return DbSet.Where(filter);
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> dbSet = DbSet;
            return include.Aggregate(dbSet, (current, expression) => current.Include(expression));
        }
    }
}