using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.PageModels;
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
        private readonly ILogger<ApiAuthenticationStateProvider> _logger;
        private readonly NavigationManager _navigationManager;

        public ApiAuthenticationStateProvider(HttpClient httpClient, ISettingsService settingsService, ILogger<ApiAuthenticationStateProvider> logger, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _settingsService = settingsService;
            _logger = logger;
            _navigationManager = navigationManager;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string savedToken = await _settingsService.GetToken();

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
            _logger.LogError("StateChanged");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            _navigationManager.NavigateTo("/");
        }
    }
}
