using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared
{
    public static class AccountPaths
    {
        public const string Name = "api/account";

        public const string LoginPath = "login";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }
}
