using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IAccountService
    {
        Task<Response<TokenModel>> AuthenticateAsync(string email, string password);
        Task<Response> RegisterAsync(RegisterModel value);
        Task<Response> UpdateAsync(EditUserModel value);
        Task<Response> DeleteAsync();
        Task<Response> ConfirmEmail(string emailToken);
    }
}
