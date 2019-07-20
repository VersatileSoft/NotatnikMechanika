
using Android.App;
using Android.Preferences;
using NotatnikMechanika.Core.Interfaces;

namespace NotatnikMechanika.Forms.Android.Services
{
    internal class SettingsService : ISettingsService
    {
        public string Token
        {
            get => PreferenceManager.GetDefaultSharedPreferences(Application.Context).GetString("Token", null);
            set => PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                    .Edit()
                    .PutString("Token", value)
                    .Apply();
        }
    }
}