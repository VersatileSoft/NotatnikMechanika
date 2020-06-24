using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(string userId, T value);
        Task<bool> CheckIfUserMatch(string userId, int Id);
        Task DeleteAsync(int Id);
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync(string userId);
        Task UpdateAsync(int Id, T value);
    }
}
