using NotatnikMechanika.Shared.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(int userId, CustomerModel value);
        Task<bool> CheckIfUserMatch(int userId, int customerId);
        Task DeleteAsync(int customerId);
        Task<CustomerModel> GetCustomerAsync(int customerId);
        Task<IEnumerable<CustomerModel>> GetCustomersAsync(int userId);
        Task UpdateAsync(int customerId, CustomerModel value);
    }
}
