using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface IAccountService
    {
        Task<ActionResult<TokenModel>> AuthenticateAsync(string email, string password);
        Task<ActionResult> RegisterAsync(RegisterModel value);
        Task<ActionResult> UpdateAsync(EditUserModel value);
        Task<ActionResult> DeleteAsync();
        Task<ActionResult> ConfirmEmail(string emailToken);
    }
}
