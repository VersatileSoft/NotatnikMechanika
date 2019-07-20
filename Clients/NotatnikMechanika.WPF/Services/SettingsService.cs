using NotatnikMechanika.Core.Interfaces;
using System.Configuration;

namespace NotatnikMechanika.WPF.Services
{
    public class SettingsService : ISettingsService
    {
        public string Token
        {
            get
            {
                try
                {
                    return Settings.Default.Token as string;
                }
                catch (SettingsPropertyNotFoundException)
                {
                    return null;
                }
            }
            set
            {
                Settings.Default.Token = value;
                Settings.Default.Save();
            }
        }
    }
}
