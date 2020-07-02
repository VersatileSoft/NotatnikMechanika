using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IAuthService
    {
        event EventHandler AuthChanged;
        Task<LoginResult> LoginAsync(LoginModel loginModel);
        Task<RegisterResult> RegisterAsync(RegisterModel registerModel);
        Task LogoutAsync();
    }
}
