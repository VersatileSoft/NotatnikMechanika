using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Service.Interfaces.Base
{
    public interface IServiceBase<TModel>
    {
        Task<Response<IEnumerable<TModel>>> AllAsync(string userId);
        Task<Response<TModel>> ByIdAsync(string userId, int id);
        Task<Response> CreateAsync(string userId, TModel value);
        Task<Response> UpdateAsync(string userId, int id, TModel value);
        Task<Response> DeleteAsync(string userId, int id);
    }
}
