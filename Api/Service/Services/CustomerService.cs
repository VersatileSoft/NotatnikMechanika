using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Service.Services
{
    public class CustomerService : ServiceBase<CustomerModel>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }
    }
}
