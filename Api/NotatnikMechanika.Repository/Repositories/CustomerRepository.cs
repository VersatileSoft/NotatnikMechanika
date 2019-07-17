using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NotatnikMechanikaDbContext _dbContext;
        public CustomerRepository(NotatnikMechanikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfUserMatch(int userId, int customerId)
        {
            return await _dbContext.Customers.Where(a => a.UserId == userId).Where(a => a.Id == customerId).AnyAsync();
        }

        public async Task CreateAsync(int userId, CustomerModel value)
        {
            await _dbContext.Customers.AddAsync(new Customer
            {
                Address = value.Address,
                UserId = userId,
                SureName = value.SureName,
                Phone = value.Phone,
                CompanyIdentyficator = value.CompanyIdentyficator,
                CompanyName = value.CompanyName,
                Name = value.Name
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int customerId)
        {
            _dbContext.Customers.Remove(await _dbContext.Customers.Where(a => a.Id == customerId).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CustomerModel> GetCustomerAsync(int customerId)
        {
            return await _dbContext.Customers.Where(a => a.Id == customerId).Select(value => new CustomerModel
            {
                Address = value.Address,
                SureName = value.SureName,
                Phone = value.Phone,
                CompanyIdentyficator = value.CompanyIdentyficator,
                CompanyName = value.CompanyName,
                Name = value.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync(int userId)
        {
            return await _dbContext.Customers.Where(a => a.UserId == userId).Select(value => new CustomerModel
            {
                Address = value.Address,
                SureName = value.SureName,
                Phone = value.Phone,
                CompanyIdentyficator = value.CompanyIdentyficator,
                CompanyName = value.CompanyName,
                Name = value.Name
            }).ToListAsync();
        }

        public async Task UpdateAsync(int customerId, CustomerModel value)
        {
            Customer customer = await _dbContext.Customers.Where(a => a.Id == customerId).FirstOrDefaultAsync();
            customer.Address = value.Address;
            customer.SureName = value.SureName;
            customer.Phone = value.Phone;
            customer.CompanyIdentyficator = value.CompanyIdentyficator;
            customer.CompanyName = value.CompanyName;
            customer.Name = value.Name;
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
