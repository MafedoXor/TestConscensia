using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Data;
using TestConscensia.Data.Base;

namespace TestConscensia.Abstractions.DataServices
{
    public abstract class DataServiceBase<TSource, TDest> : IDataServiceBase<TSource> where TSource : class where TDest : class, IBaseEntity
    {
        private readonly IAppMapper _appMapper;

        public DataServiceBase(IAppMapper appMapper)
        {
            _appMapper = appMapper;
        }

        public virtual async Task<bool> Add(TSource model)
        {
            using (var unit = new UnitOfWork())
            {
                var entity = MapToEntity(model);
                var repo = GetRepository(unit);
                await repo.Insert(entity);
            }

            return true;
        }

        public virtual async Task<IEnumerable<TSource>> GetAll()
        {
            using (var unit = new UnitOfWork())
            {
                var repo = GetRepository(unit);
                return (await repo.GetAll()).Select(MapToDomainModel).ToList();
            }
        }

        public virtual async Task<bool> Upsert(TSource model)
        {
            using (var unit = new UnitOfWork())
            {
                var repo = GetRepository(unit);
                await repo.InsertOrUpdate(MapToEntity(model));
            }
            return true;
        }

        public virtual async Task<bool> AddRange(IEnumerable<TSource> list)
        {
            using (var unit = new UnitOfWork())
            {
                var entities = list.Select(MapToEntity);
                var repo = GetRepository(unit);
                await repo.Insert(entities);
            }
            return true;
        }

        public virtual async Task<bool> UpsertRange(IEnumerable<TSource> list)
        {
            using (var unit = new UnitOfWork())
            {
                var entities = list.Select(MapToEntity);
                var repo = GetRepository(unit);
                await repo.InsertOrUpdate(entities);
            }
            return true;
        }

        public virtual async Task<bool> Remove(TSource model)
        {
            using (var unit = new UnitOfWork())
            {
                var repo = GetRepository(unit);
                await repo.Delete(MapToEntity(model));
            }
            return true;
        }

        protected virtual TDest MapToEntity(TSource model)
        {
            if (model == null)
            {
                return null;
            }

            return _appMapper.Map<TSource, TDest>(model);
        }

        protected virtual TSource MapToDomainModel(TDest entity)
        {
            if (entity == null)
            {
                return null;
            }

            return _appMapper.Map<TDest, TSource>(entity);
        }

        protected abstract IRepository<TDest> GetRepository(UnitOfWork unit);
    }
}
