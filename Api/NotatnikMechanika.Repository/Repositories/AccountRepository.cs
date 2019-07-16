using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Component;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private NotatnikMechanikaDbContext DbContext { get; set; }
        public AccountRepository(NotatnikMechanikaDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<bool> CheckIfAccountExistAsync(string email)
        {
            return await DbContext.Users.Where(a => a.Email == email).AnyAsync();
        }

        public async Task CreateUserAccountAsync(CreateUserModel value)
        {
            byte[] salt = Helpers.GenerateSalt();

            User user = new User
            {
                Name = value.Name,
                Email = value.Email,
                HashedPassword = Helpers.HashPassword(value.Password, salt),
                Salt = salt,
                Surname = value.Surname,
                UserName = value.UserName
            };

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await DbContext.Users.Where(a => a.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
