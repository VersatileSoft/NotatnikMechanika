using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Repository.Interfaces.Base
{
    public interface IRepositoryBase<TEntity>
    {
        Task CreateAsync(string userId, TEntity value);
        Task<bool> CheckIfUserMatch(string userId, int id);
        Task DeleteAsync(TEntity id);
        Task<TEntity> ByIdAsync(int id);
        Task<IEnumerable<TEntity>> AllAsync(string userId);
        Task UpdateAsync(TEntity value);
    }
}
