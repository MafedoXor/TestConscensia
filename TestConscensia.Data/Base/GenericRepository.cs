using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace TestConscensia.Data.Base
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected IDbContext Context { get; }
        private DbSet<TEntity> _entities;

        public GenericRepository(IDbContext context)
        {
            Context = context;
        }

        protected virtual DbSet<TEntity> DBSet
        {
            get
            {
                if (_entities == null)
                    _entities = Context.Set<TEntity>();
                return _entities;
            }
        }

        public virtual IQueryable<TEntity> Table
        {
            get { return DBSet; }
        }

        public virtual List<TEntity> Entities
        {
            get { return DBSet.AsNoTracking().ToList(); }
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return DBSet.ToListAsync();
        }

        public virtual Task Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            DBSet.Add(entity);
            return Context.SaveChangesAsync();
        }

        public virtual Task InsertOrUpdate(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            DBSet.AddOrUpdate(entity);

            return Context.SaveChangesAsync();
        }

        public virtual Task InsertOrUpdate(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities)
            {
                if (entity == null) throw new ArgumentNullException("entity");
                DBSet.AddOrUpdate(entity);
            }

            return Context.SaveChangesAsync();
        }

        public virtual Task Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            DBSet.AddRange(entities);

            return Context.SaveChangesAsync();
        }

        public virtual Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            DBSet.AddOrUpdate(entity);

            return Context.SaveChangesAsync();
        }

        public virtual Task Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            DBSet.Attach(entity);

            DBSet.Remove(entity);

            return Context.SaveChangesAsync();
        }
    }
}