using AutoMapper;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Api.Service.Services
{
    public class CustomerService : ServiceBase<CustomerModel, Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
        }
    }
}
