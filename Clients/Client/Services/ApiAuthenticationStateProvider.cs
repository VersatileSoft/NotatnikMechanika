using Microsoft.AspNetCore.Components.Authorization;
using NotatnikMechanika.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ISettingsService _settingsService;

        public ApiAuthenticationStateProvider(HttpClient httpClient, ISettingsService settingsService)
        {
            _httpClient = httpClient;
            _settingsService = settingsService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string savedToken = await _settingsService.Token;

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
            JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(savedToken);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "jwt")));
        }

        public void StateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
