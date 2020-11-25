using NotatnikMechanika.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface ICarRepository : IRepositoryBase<CarModel>
    {
        Task<IEnumerable<CarModel>> ByCustomerAsync(string userId, int customerId);
    }
}
