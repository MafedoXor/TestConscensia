using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConscensia.Abstractions.DataServices
{
    public interface IDataServiceBase<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> AddRange(IEnumerable<T> list);
        Task<bool> Remove(T entity);
        Task<bool> Upsert(T entity);
        Task<bool> UpsertRange(IEnumerable<T> entity);
        Task<IEnumerable<T>> GetAll();
    }
}
