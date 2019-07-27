using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces.Base
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string userId);
        Task<T> GetAsync(string userId, int Id);
        Task CreateAsync(string userId, T value);
        Task UpdateAsync(string userId, int Id, T value);
        Task DeleteAsync(string userId, int Id);
    }
}
