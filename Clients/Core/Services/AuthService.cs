using MvvmPackage.Core.Attributes;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Services
{
    [SingleInstance]
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ISettingsService _settingsService;
        private readonly IHttpRequestService _httpRequestService;

        public event EventHandler? AuthChanged;

        public AuthService(ISettingsService settingsService, HttpClient httpClient, IHttpRequestService httpRequestService)
        {
            _httpClient = httpClient;
            _settingsService = settingsService;
            _httpRequestService = httpRequestService;
        }

        public async Task LoginAsync(LoginModel loginModel)
        {
            var token = await _httpRequestService.SendPost<TokenModel>(loginModel, AccountPaths.Login());
            if (token.Token != null)
            {
                await _settingsService.SetToken(token.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);
                AuthChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public async Task LogoutAsync()
        {
            await _settingsService.SetToken(string.Empty);
            _httpClient.DefaultRequestHeaders.Authorization = null;
            AuthChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
