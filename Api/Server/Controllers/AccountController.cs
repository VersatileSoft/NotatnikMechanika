using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;

namespace NotatnikMechanika.Server.Controllers
{
    [Route(AccountPaths.Name)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(AccountPaths.LoginPath)]
        public Task<ActionResult<TokenModel>> LoginAsync([FromBody] LoginModel loginModel)
        {
            return _accountService.AuthenticateAsync(loginModel.Email, loginModel.Password);
        }

        [HttpGet("verify/email")]
        public async Task<RedirectResult> ConfirmEmail(string emailToken)
        {
            await _accountService.ConfirmEmail(emailToken);
            return Redirect($"{Request.Scheme}://{Request.Host.Value}");
        }

        [HttpPost(AccountPaths.RegisterPath)]
        public Task<ActionResult> RegisterAsync([FromBody] RegisterModel value)
        {
            return _accountService.RegisterAsync(value);
        }

        [Authorize]
        [HttpPut(AccountPaths.UpdatePath)]
        public Task<ActionResult> UpdateUserAsync([FromBody] EditUserModel value)
        {
            return _accountService.UpdateAsync(value);
        }

        [Authorize]
        [HttpDelete(AccountPaths.DeletePath)]
        public Task<ActionResult> DeleteAsync()
        {
            return _accountService.DeleteAsync();
        }
    }
}
