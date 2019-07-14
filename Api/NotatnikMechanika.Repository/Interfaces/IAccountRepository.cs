using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> FindByUserNameAsync(string userName);
        Task<bool> CheckIfAccountExistAsync(string email);
        Task CreateUserAccountAsync(CreateUserModel value);
    }
}
