using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.PageModels;
using System;

namespace NotatnikMechanika.Core
{
    public class MainPageService : IMainPageService
    {
        private readonly ISettingsService _settingsService;

        public MainPageService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Type GetMainPageModelType()
        {
            bool isAuthenticated = !string.IsNullOrEmpty(_settingsService.Token);

            if (isAuthenticated)
            {
                return typeof(MainPageModel);
            }
            else
            {
                return typeof(LoginPageModel);
            }
        }
    }
}