using System;
using System.Collections.Generic;

namespace NotatnikMechanika.WinForms
{
    [Serializable]
    public class FirstOpenSettings
    {
        public List<string> columns = new List<string>();

        public bool demo = true;

        public bool firstOpen = true;

        public string password;
        public bool isPassword;
    }
}