using System.Collections.Generic;
using System.Threading.Tasks;
using TestConscensia.Models.Base;

namespace TestConscensia.Abstractions.DataServices
{
    public interface IDataServiceBase<T> where T : class, IBaseModel
    {
        Task<bool> Add(T entity);

        Task<bool> AddRange(IEnumerable<T> list);

        Task<bool> Remove(T entity);

        Task<bool> Upsert(T entity);

        Task<bool> UpsertRange(IEnumerable<T> entity);

        Task<IEnumerable<T>> GetAll();
    }
}