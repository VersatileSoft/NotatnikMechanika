using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckIfAccountExistAsync(string email);
        Task CreateUserAccountAsync(CreateUserModel value);
    }
}
