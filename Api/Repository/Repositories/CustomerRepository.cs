using AutoMapper;
using NotatnikMechanika.Api.Data;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;

namespace NotatnikMechanika.Api.Repository.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
