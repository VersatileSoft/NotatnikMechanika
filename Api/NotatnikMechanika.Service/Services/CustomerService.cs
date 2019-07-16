using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateAsync(int userId, CustomerModel value)
        {
            await _customerRepository.CreateAsync(userId, value);
        }

        public async Task DeleteAsync(int userId, int CustomerId)
        {
            if (await _customerRepository.CheckIfUserMatch(userId, CustomerId))
            {
                await _customerRepository.DeleteAsync(CustomerId);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This customer is not yours or not exsists");
            }
        }

        public async Task<CustomerModel> GetCustomerAsync(int userId, int CustomerId)
        {
            if (await _customerRepository.CheckIfUserMatch(userId, CustomerId))
            {
                return await _customerRepository.GetCustomerAsync(CustomerId);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This customer is not yours or not exsists");
            }
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync(int userId)
        {
            return await _customerRepository.GetCustomersAsync(userId);
        }

        public async Task UpdateAsync(int userId, int CustomerId, CustomerModel value)
        {
            if (await _customerRepository.CheckIfUserMatch(userId, CustomerId))
            {
                await _customerRepository.UpdateAsync(CustomerId, value);
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "This customer is not yours or not exsists");
            }
        }
    }
}
