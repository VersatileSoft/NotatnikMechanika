using AutoMapper;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerModel, Customer>, ICustomerRepository
    {
        public CustomerRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
