using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IAccountService
    {
        Task<TokenModel> AuthenticateAsync(string email, string password);
        Task CreateAsync(CreateUserModel value);
        Task UpdateAsync(int id, EditUserModel value);
        Task DeleteAsync(int id);
        Task ConfirmEmail(string userId, string emailToken);
    }
}
