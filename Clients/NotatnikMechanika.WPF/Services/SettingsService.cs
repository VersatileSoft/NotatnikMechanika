using NotatnikMechanika.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NotatnikMechanika.WPF.Services
{
    public class SettingsService : ISettingsService
    {
        public string Token
        {
            get {
                try
                {
                    return Settings.Default.Token as string;
                }
                catch (SettingsPropertyNotFoundException)
                {
                    return null;
                }
            }
            set {
                Settings.Default.Token = value;
                Settings.Default.Save();
            }
        }
    }
}
