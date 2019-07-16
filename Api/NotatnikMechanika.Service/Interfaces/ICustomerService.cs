using NotatnikMechanika.Shared.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync(int userId);
        Task<CustomerModel> GetCustomerAsync(int userId, int customerId);
        Task CreateAsync(int userId, CustomerModel value);
        Task UpdateAsync(int userId, int customerId, CustomerModel value);
        Task DeleteAsync(int userId, int customerId);
    }
}
