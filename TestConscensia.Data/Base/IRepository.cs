using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestConscensia.Data.Base
{
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        List<TEntity> Entities { get; }

        IQueryable<TEntity> Table { get; }

        Task Insert(TEntity entity);
        Task Insert(IEnumerable<TEntity> entities);
        Task InsertOrUpdate(TEntity entity);
        Task InsertOrUpdate(IEnumerable<TEntity> entity);
        Task Update(TEntity entityToUpdate);
        Task Delete(TEntity entity);
    }
}