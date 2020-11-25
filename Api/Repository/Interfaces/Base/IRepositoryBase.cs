using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(string userId, T value);
        Task<bool> CheckIfUserMatch(string userId, int id);
        Task DeleteAsync(int id);
        Task<T> ByIdAsync(int id);
        Task<IEnumerable<T>> AllAsync(string userId);
        Task UpdateAsync(int id, T value);
    }
}
