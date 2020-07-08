using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IAccountService
    {
        Task<Response<TokenModel>> AuthenticateAsync(string email, string password);
        Task<Response> RegisterAsync(RegisterModel value);
        Task<Response> UpdateAsync(int id, EditUserModel value);
        Task<Response> DeleteAsync(int id);
        Task<Response> ConfirmEmail(string userId, string emailToken);
    }
}
