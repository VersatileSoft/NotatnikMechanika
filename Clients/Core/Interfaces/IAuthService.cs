using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IAuthService
    {
        event EventHandler AuthChanged;
        Task<TokenModel> LoginAsync(LoginModel loginModel);
        Task<Response> RegisterAsync(RegisterModel registerModel);
        Task LogoutAsync();
    }
}
