using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

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

        public async Task<TokenModel> AuthenticateAsync(string email, string password)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                User user = await _userManager.Users.SingleOrDefaultAsync(r => r.Email == email);
                return new TokenModel
                {
                    Token = GenerateToken(user)
                };
            }

            if (result.IsNotAllowed)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Potwierdź adres email aby się zalogować.");
            }

            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Nieprawidłowy login lub hasło");
        }

        public async Task ConfirmEmail(string userId, string emailToken)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Nie znaleziono użytkownika");
            }

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, emailToken);

            if (!result.Succeeded)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Link nieprawidłowy.");
            }
        }

        public async Task CreateAsync(CreateUserModel value)
        {
            User user = new User
            {
                UserName = value.Email,
                Email = value.Email,
                Name = value.Name,
                Surname = value.Surname
            };

            IdentityResult result = await _userManager.CreateAsync(user, value.Password);

            if (result.Succeeded)
            {
                User newUser = await _userManager.FindByEmailAsync(user.Email);
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callbackUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/api/Account/verify/email?userId={WebUtility.UrlEncode(newUser.Id)}&emailToken={HttpUtility.UrlEncode(code)}";

                var message =  $"Please confirm your account by <a clicktracking=off href='{callbackUrl}'>clicking here</a>.";

                await _emailSenderService.SendEmailAsync(user.Email, "Confirm your email", message);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (IdentityError err in result.Errors)
                {
                    sb.AppendLine(err.Description);
                }

                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, sb.ToString());
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, EditUserModel value)
        {
            throw new NotImplementedException();
        }

        private string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
