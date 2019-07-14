using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IAccountService
    {
        Task<TokenModel> AuthenticateAsync(string userName, string password);
        Task CreateAsync(CreateUserModel value);
        Task UpdateAsync(int id, EditUserModel value);
        Task DeleteAsync(int id);
    }
}
