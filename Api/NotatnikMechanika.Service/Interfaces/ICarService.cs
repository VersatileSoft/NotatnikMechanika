using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Car;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICarService : IServiceBase<CarModel>
    {
        Task<IEnumerable<CarModel>> GetCarsByCustomerAsync(string userId, int customerId);
    }
}
