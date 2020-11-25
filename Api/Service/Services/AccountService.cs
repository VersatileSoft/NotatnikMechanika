using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(
            IOptions<AppSettings> appSettings,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSenderService emailSenderService,
            IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSenderService = emailSenderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<TokenModel>> AuthenticateAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
                return FailureResponse<TokenModel>(ResponseType.Failure,
                    result.IsNotAllowed
                        ? new List<string> {"Potwierdź adres email aby się zalogować."}
                        : new List<string> {"Nieprawidłowy login lub hasło"});
            
            var user = await _userManager.Users.SingleOrDefaultAsync(r => r.Email == email);

            return SuccessResponse(new TokenModel
            {
                Token = GenerateToken(user)
            });

        }

        public async Task<Response> ConfirmEmail(string userId, string emailToken)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return FailureResponse(ResponseType.Failure, new List<string> { "Nie znaleziono użytkownika" });
            }

            var result = await _userManager.ConfirmEmailAsync(user, emailToken);

            return !result.Succeeded ? 
                FailureResponse(ResponseType.Failure, new List<string> { "Link nieprawidłowy." }) : 
                SuccessResponse();
        }

        public async Task<Response> RegisterAsync(RegisterModel registerModel)
        {
            var user = new User
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
                Name = registerModel.Name,
                Surname = registerModel.Surname
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            return result.Succeeded ? 
                SuccessResponse() : 
                FailureResponse(ResponseType.Failure, result.Errors.Select(e => e.Description).ToList());
        }

        public async Task<Response> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return SuccessResponse();
        }

        public Task<Response> UpdateAsync(string id, EditUserModel value)
        {
            throw new NotImplementedException();
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
