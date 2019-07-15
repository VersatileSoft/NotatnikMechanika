using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotatnikMechanika.Core.Interfaces;

namespace NotatnikMechanika.Forms.Android.Services
{
    class SettingsService : ISettingsService
    {
        public string Token
        {
            get => PreferenceManager.GetDefaultSharedPreferences(Application.Context).GetString("Token", null);
            set
            {
                PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                    .Edit()
                    .PutString("Token", value)
                    .Apply();
            }
        }
    }
}