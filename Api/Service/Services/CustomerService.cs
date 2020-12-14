using AutoMapper;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Service.Services
{
    public class CustomerService : ServiceBase<CustomerModel, Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
        }
    }
}
