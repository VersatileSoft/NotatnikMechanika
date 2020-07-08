using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces.Base
{
    public interface IServiceBase<TModel>
    {
        Task<Response<IEnumerable<TModel>>> GetAllAsync(string userId);
        Task<Response<TModel>> GetAsync(string userId, int Id);
        Task<Response> CreateAsync(string userId, TModel value);
        Task<Response> UpdateAsync(string userId, int Id, TModel value);
        Task<Response> DeleteAsync(string userId, int Id);
    }
}
