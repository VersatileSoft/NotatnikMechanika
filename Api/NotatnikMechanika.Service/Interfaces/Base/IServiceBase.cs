using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces.Base
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync(int userId);
        Task<T> GetAsync(int userId, int Id);
        Task CreateAsync(int userId, T value);
        Task UpdateAsync(int userId, int Id, T value);
        Task DeleteAsync(int userId, int Id);
    }
}
