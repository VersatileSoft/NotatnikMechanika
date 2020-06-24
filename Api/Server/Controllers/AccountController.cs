﻿using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<LoginResult>> LoginAsync([FromBody] LoginModel loginModel)
        {
            LoginResult result = await _accountService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (result.Successful)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }

        [HttpGet("verify/email")]
        public async Task<RedirectResult> ConfirmEmail(string userId, string emailToken)
        {
            await _accountService.ConfirmEmail(userId, emailToken);
            return Redirect($"{Request.Scheme}://{Request.Host.Value}");
        }

        [HttpPost(AccountPaths.RegisterPath)]
        public async Task<ActionResult<RegisterResult>> RegisterAsync([FromBody] RegisterModel value)
        {
            RegisterResult result = await _accountService.RegisterAsync(value);

            if (result.Successful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize]
        [HttpPut(AccountPaths.UpdatePath)]
        public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] EditUserModel value)
        {
            await _accountService.UpdateAsync(id, value);
            return Ok();
        }

        [Authorize]
        [HttpDelete(AccountPaths.DeletePath)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _accountService.DeleteAsync(id);
            return Ok();
        }
    }
}