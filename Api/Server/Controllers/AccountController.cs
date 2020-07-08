using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

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
        public async Task<ActionResult<Response<TokenModel>>> LoginAsync([FromBody] LoginModel loginModel)
        {
            Response<TokenModel> loginResponse = await _accountService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (loginResponse.Successful)
            {
                return Ok(loginResponse);
            }
            else
            {
                return Unauthorized(loginResponse);
            }
        }

        [HttpGet("verify/email")]
        public async Task<RedirectResult> ConfirmEmail(string userId, string emailToken)
        {
            await _accountService.ConfirmEmail(userId, emailToken);
            return Redirect($"{Request.Scheme}://{Request.Host.Value}");
        }

        [HttpPost(AccountPaths.RegisterPath)]
        public async Task<ActionResult<Response>> RegisterAsync([FromBody] RegisterModel value)
        {
            Response result = await _accountService.RegisterAsync(value);

            if (result.Successful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize]
        [HttpPut(AccountPaths.UpdatePath)]
        public async Task<ActionResult<Response>> UpdateUserAsync(int id, [FromBody] EditUserModel value)
        {
            return Ok(await _accountService.UpdateAsync(id, value));
        }

        [Authorize]
        [HttpDelete(AccountPaths.DeletePath)]
        public async Task<ActionResult<Response>> DeleteAsync(int id)
        {
            return Ok(await _accountService.DeleteAsync(id));
        }
    }
}
