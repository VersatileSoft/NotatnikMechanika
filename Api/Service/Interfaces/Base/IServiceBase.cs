using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Data.Models;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces.Base
{
    public interface IServiceBase<TModel> 
    {
        Task<Response<IEnumerable<TModel>>> AllAsync();
        Task<Response<TModel>> ByIdAsync(int id);
        Task<Response> CreateAsync(TModel value);
        Task<Response> UpdateAsync(int id, TModel value);
        Task<Response> DeleteAsync(int id);
    }
}
