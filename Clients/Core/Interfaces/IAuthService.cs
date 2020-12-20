using NotatnikMechanika.Shared.Models.User;
using System;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IAuthService
    {
        event EventHandler AuthChanged;
        Task LoginAsync(LoginModel loginModel);
        Task LogoutAsync();
    }
}
