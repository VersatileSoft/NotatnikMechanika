using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IServiceService : IServiceBase<ServiceModel>
    {
        Task<Response<IEnumerable<ServiceForOrderModel>>> GetServicesForOrder(string userId, int orderId);
        Task<Response<IEnumerable<ServiceModel>>> GetServicesInOrder(string userId, int orderId);
    }
}
