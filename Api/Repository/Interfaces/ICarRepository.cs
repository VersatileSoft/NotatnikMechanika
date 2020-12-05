using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Repository.Interfaces
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        Task<IEnumerable<CarModel>> ByCustomerAsync(int customerId);
    }
}
