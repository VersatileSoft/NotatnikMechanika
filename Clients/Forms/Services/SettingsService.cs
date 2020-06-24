using NotatnikMechanika.Core.Interfaces;
using Xamarin.Essentials;

namespace NotatnikMechanika.Forms.Services
{
    public class SettingsService : ISettingsService
    {
        public string Token
        {
            get => Preferences.Get("Token", null);
            set => Preferences.Set("Token", value);
        }
    }
}