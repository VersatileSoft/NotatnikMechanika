using NotatnikMechanika.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class SettingsService : ISettingsService
    {
        public string Token { get; set; }
    }
}
