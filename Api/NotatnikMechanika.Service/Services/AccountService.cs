using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NotatnikMechanika.Component;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AppSettings _appSettings;
        public AccountService(IOptions<AppSettings> appSettings, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<TokenModel> AuthenticateAsync(string email, string password)
        {
            User user = await _accountRepository.FindByEmailAsync(email);

            if (user == null || user.HashedPassword != Helpers.HashPassword(password, user.Salt))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Nieprawidłowy login lub hasło");
            }

            return new TokenModel
            {
                Token = GenerateToken(user)
            };
        }

        public async Task CreateAsync(CreateUserModel value)
        {
            if (await _accountRepository.CheckIfAccountExistAsync(value.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Użytkownik z tym adresem już istnieje.");
            }

            await _accountRepository.CreateUserAccountAsync(value);
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
