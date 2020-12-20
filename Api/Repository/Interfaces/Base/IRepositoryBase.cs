using Microsoft.EntityFrameworkCore.Storage;
using NotatnikMechanika.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces.Base
{
    public interface IRepositoryBase<TEntity>
    {
        string CurrentUserId { get; }
        Task CreateAsync(TEntity value);
        Task DeleteAsync(TEntity id);
        Task<TEntity> ByIdAsync(int id);
        Task<IEnumerable<TEntity>> AllAsync();
        Task UpdateAsync(TEntity value);
        Task<bool> Transaction(Func<Task> action);
    }
}
