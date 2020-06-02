using StorageInstruments.DataContract.Utils;
using StorageInstruments.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageInstruments.DataContract.Repository
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task<T> FindOneAsync(long id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T toCreate);
        Task<T> UpdateAsync(long id, T toCreate);
        Task<T> DeleteAsync(long id);
    }
}
