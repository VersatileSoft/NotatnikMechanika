using System.Collections.Generic;
using System.Threading.Tasks;
using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Car;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface ICarRepository : IRepositoryBase<CarModel>
    {
        Task<IEnumerable<CarModel>> GetCarsByCustomerAsync(string userId, int customerId);
    }
}
