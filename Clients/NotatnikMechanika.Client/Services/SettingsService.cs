using NotatnikMechanika.Core.Interfaces;

namespace NotatnikMechanika.Client.Services
{
    public class SettingsService : ISettingsService
    {
        public string Token { get; set; }
    }
}
