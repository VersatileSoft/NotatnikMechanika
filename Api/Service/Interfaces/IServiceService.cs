using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IServiceService : IServiceBase<ServiceModel>
    {
        Task<Response<IEnumerable<ServiceModel>>> AllAsync(string userId, int orderId);
        Task<Response<IEnumerable<ServiceModel>>> ByOrderAsync(string userId, int orderId);
    }
}
