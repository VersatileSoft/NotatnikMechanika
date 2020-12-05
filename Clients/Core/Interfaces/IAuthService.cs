using NotatnikMechanika.Shared.Models.User;
using System;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IAuthService
    {
        Task AuthorizeAsync();
        event EventHandler AuthChanged;
        Task<Response<TokenModel>> LoginAsync(LoginModel loginModel);
        Task LogoutAsync();
    }
}
