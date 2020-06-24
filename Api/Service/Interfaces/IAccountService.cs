using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResult> AuthenticateAsync(string email, string password);
        Task<RegisterResult> RegisterAsync(RegisterModel value);
        Task UpdateAsync(int id, EditUserModel value);
        Task DeleteAsync(int id);
        Task ConfirmEmail(string userId, string emailToken);
    }
}
