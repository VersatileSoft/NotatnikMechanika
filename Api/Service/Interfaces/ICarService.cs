using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICarService : IServiceBase<CarModel>
    {
        Task<Response<IEnumerable<CarModel>>> ByCustomerAsync(int customerId);
    }
}
