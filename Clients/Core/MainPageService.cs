using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.PageModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NotatnikMechanika.Core
{
    public class MainPageService : IMainPageService
    {
        private readonly ISettingsService _settingsService;
        private readonly HttpClient _httpClient;

        public MainPageService(ISettingsService settingsService, HttpClient httpClient)
        {
            _settingsService = settingsService;
            _httpClient = httpClient;
        }

        public Type GetMainPageModelType()
        {
            string token = _settingsService.GetToken().Result;

            if (!string.IsNullOrEmpty(""))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return typeof(MainPageModel);
            }
            else
            {
                return typeof(LoginPageModel);
            }
        }
    }
}