using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(int userId, T value);
        Task<bool> CheckIfUserMatch(int userId, int Id);
        Task DeleteAsync(int Id);
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync(int userId);
        Task UpdateAsync(int Id, T value);
    }
}
